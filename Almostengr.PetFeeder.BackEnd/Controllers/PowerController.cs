using Almostengr.PetFeeder.BackEnd.Services;
using Almostengr.PetFeeder.BackEnd.Constants;
using Almostengr.PetFeeder.Common.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PowerController : BaseApiController
    {
        private readonly ILogger<PowerController> _logger;
        private readonly IPowerService _service;

        public PowerController(ILogger<PowerController> logger, IPowerService service) : base(logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public ActionResult CreatePower(PowerDto powerDto)
        {
            switch(powerDto.Action)
            {
                case PowerAction.Reboot:
                    _service.Reboot();
                    return Ok("Rebooted");
                case PowerAction.Shutdown:
                    _service.Shutdown();
                    return Ok("Shutdown");
                default:
                    return BadRequest("Action was not valid");
            }
        }

    }
}