using System.Diagnostics;
using Almostengr.PetFeeder.Common.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers.Api
{
    public class PowerController : BaseApiController
    {
        private readonly ILogger<BaseApiController> _logger;

        public PowerController(ILogger<BaseApiController> logger) : base(logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult CreatePower(PowerDto powerDto)
        {
            if (powerDto == null)
            {
                return BadRequest();
            }

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            if (powerDto.Action == "restart" || powerDto.Action == "reboot")
            {
                _logger.LogInformation("System restart requested");

                startInfo.FileName = "reboot";
            }
            else if (powerDto.Action == "shutdown")
            {
                _logger.LogInformation("System shutdown requested");

                startInfo.FileName = "shutdown";
                startInfo.ArgumentList.Add("-h");
                startInfo.ArgumentList.Add("now");
            }
            else
            {
                return BadRequest();
            }

            startInfo.UseShellExecute = true;
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.Start();

            return Ok();
        }

    }
}