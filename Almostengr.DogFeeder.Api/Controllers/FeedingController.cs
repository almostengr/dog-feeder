using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Api.Controllers
{
    public class FeedingController : DfControllerBase, IControllerBase
    {
        private readonly ILogger<FeedingController> _logger;
        private readonly AppSettings _appSettings;

        public FeedingController(ILogger<FeedingController> logger, AppSettings appSettings) : 
            base(logger, appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }
        
    }
}