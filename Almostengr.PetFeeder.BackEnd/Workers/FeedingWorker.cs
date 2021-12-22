using System;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.BackEnd.Repository.Interfaces;
using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Workers
{
    public class FeedingWorker : BaseWorker
    {
        private readonly IFeedingService _foodService;
        private readonly IScheduleService _scheduleService;
        private readonly ILogger<FeedingWorker> _logger;
        private readonly IFeedingRepository _repository;

        public FeedingWorker(ILogger<FeedingWorker> logger, 
            IFeedingRepository fbRepository,
            IScheduleService scheduleService,
            IFeedingService foodService) : base()
        {
            _foodService = foodService;
            _scheduleService = scheduleService;
            _logger = logger;
            _repository = fbRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                DateTime currentDateTime = DateTime.Now;

                // check if current time matches scheduled feeding time 
                // if so, feed the pet
            
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}