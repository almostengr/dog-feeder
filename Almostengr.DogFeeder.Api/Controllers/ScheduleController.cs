using System.Collections.Generic;
using Almostengr.DogFeeder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Api.Controllers
{
    public class ScheduleController : DfControllerBase, IControllerBase
    {
        private readonly ILogger<FeedingController> _logger;
        private readonly AppSettings _appSettings;

        public ScheduleController(ILogger<FeedingController> logger, AppSettings appSettings) : 
            base(logger, appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

    }
}