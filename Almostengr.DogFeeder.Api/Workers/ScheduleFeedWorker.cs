using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.DogFeeder.Api.Data;
using Almostengr.DogFeeder.Api.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Almostengr.DogFeeder.Api.Worker
{
    public class ScheduleFeedWorker : BackgroundService
    {
        private readonly ILogger<ScheduleFeedWorker> _logger;
        private readonly IScheduleRepository _schedule;
        private readonly IFeedingRepository _feeding;
        private HttpClient _httpClient;

        public ScheduleFeedWorker(ILogger<ScheduleFeedWorker> logger, IScheduleRepository schedule, IFeedingRepository feeding)
        {
            _logger = logger;
            _schedule = schedule;
            _feeding = feeding;
        }

        public override void Dispose()
        {
            _httpClient.Dispose();
            base.Dispose();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting worker");
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost");

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping worker");

            _httpClient.Dispose();
            
            return base.StopAsync(cancellationToken);
        }

        public override string ToString()
        {
            return base.ToString();
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

                await Task.Delay(TimeSpan.FromSeconds(25));
            }
        }

        private async Task<List<Schedule>> GetActiveSchedules(bool firstRun)
        {
            _logger.LogInformation("Refreshing schedule information");
            return await _schedule.GetAllActiveSchedulesAsync();
        }

        private async Task CompareScheduleToFeedTime(List<Schedule> schedules)
        {
            DateTime currentTime = DateTime.Now;

            foreach (var schedule in schedules)
            {
                if (schedule.ScheduledTime.Hour == currentTime.Hour &&
                    schedule.ScheduledTime.Minute == currentTime.Minute)
                {
                    // perform the feeding
                    StringContent stringContent;
                    
                    try
                    {
                        Feeding feeding = new Feeding(schedule.Id);
                        var jsonState = JsonConvert.SerializeObject(feeding).ToLower();
                        stringContent = new StringContent(jsonState, Encoding.ASCII, "application/json");

                        // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _haToken);

                        HttpResponseMessage responseMessage = await _httpClient.PostAsync("feeding", stringContent);

                        if (responseMessage.IsSuccessStatusCode)
                        {
                            _logger.LogInformation(responseMessage.StatusCode.ToString());
                        }
                        else
                        {
                            _logger.LogError(responseMessage.StatusCode.ToString());
                        }
                        
                        stringContent.Dispose();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                    }

                    // if (stringContent != null)
                    // {
                    //     stringContent.Dispose();
                    // }
                }

                await Task.Delay(TimeSpan.FromSeconds(60));
                break;
            }
        }

    }
}