using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Web.Controllers.Api
{
    public class PowerController : BaseApiController
    {
        private readonly ILogger<BaseApiController> _logger;

        public PowerController(ILogger<BaseApiController> logger) : base(logger)
        {
            _logger = logger;
        }

        [HttpPost("shutdown")]
        public ActionResult ShutDown()
        {
            _logger.LogInformation("System shutdown requested");

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "shutdown",
                    ArgumentList = {
                        "-h",
                        "now"
                    },
                    UseShellExecute = true,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            return Ok();
        }

        [HttpPost("restart")]
        public ActionResult Restart()
        {
            _logger.LogInformation("System restart requested");

            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "reboot",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            return Ok();
        }
        
    }
}