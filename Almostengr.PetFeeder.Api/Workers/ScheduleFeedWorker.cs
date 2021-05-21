using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.PetFeeder.Api.Worker
{
    public class ScheduleFeedWorker : BaseWorker
    {
        private readonly ILogger<ScheduleFeedWorker> _logger;
        private readonly IFeedingRepository _feedingRepository;
        private HttpClient _httpClient;

        public ScheduleFeedWorker(ILogger<ScheduleFeedWorker> logger, IFeedingRepository feedingRepository)
            : base(logger)
        {
            _logger = logger;
            _feedingRepository = feedingRepository;
        }

        public override void Dispose()
        {
            _httpClient.Dispose();
            base.Dispose();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting worker");
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5000");

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping worker");

            _httpClient.Dispose();

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            List<Schedule> schedules = await GetActiveSchedules(true);

            while (!stoppingToken.IsCancellationRequested)
            {
                DateTime currentTime = DateTime.Now;

                if (currentTime.Minute % 15 == 0)
                {
                    schedules = await GetActiveSchedules(false);
                }

                await CompareScheduleToFeedTime(schedules);

                // await Task.Delay(TimeSpan.FromSeconds(25));
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        private async Task<List<Schedule>> GetActiveSchedules(bool firstRun)
        {
            _logger.LogInformation("Refreshing schedule information");

            try
            {
                HttpResponseMessage responseMessage = await _httpClient.GetAsync("schedules/active");
                if (responseMessage.IsSuccessStatusCode)
                {
                    _logger.LogInformation(responseMessage.StatusCode.ToString());
                    return JsonConvert.DeserializeObject<List<Schedule>>(responseMessage.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    _logger.LogInformation(responseMessage.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new List<Schedule>();
        }

        private async Task CompareScheduleToFeedTime(List<Schedule> schedules)
        {
            DateTime currentTime = DateTime.Now;

            foreach (var schedule in schedules)
            {
                if (schedule.ScheduledTime.Hour == currentTime.Hour && schedule.ScheduledTime.Minute == currentTime.Minute)
                {
                    await PerformFeeding(schedule);
                    break;
                }
            }
        }

        private async Task PerformFeeding(Schedule schedule)
        {
            try
            {
                Feeding feeding = new Feeding();
                feeding.Timestamp = DateTime.Now;
                feeding.Amount = schedule.FeedingAmount;
                feeding.ScheduleId = schedule.Id;

                // run the motor to dispense food

                await _feedingRepository.CreateFeeding(feeding);
                await _feedingRepository.SaveChangesAsync();

                await Task.Delay(TimeSpan.FromSeconds(60));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

    }
}