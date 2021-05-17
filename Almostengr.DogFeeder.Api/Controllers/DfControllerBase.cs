using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.DogFeeder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DfControllerBase : ControllerBase
    {
        private readonly ILogger<DfControllerBase> _logger;
        private AppSettings _appSettings;

        public DfControllerBase(ILogger<DfControllerBase> logger, AppSettings appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

    }
}