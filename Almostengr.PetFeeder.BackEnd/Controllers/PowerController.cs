using Almostengr.PetFeeder.BackEnd.Services.Interfaces;
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
            if (powerDto.Action == PowerAction.Reboot)
            {
                _service.Reboot();
            }
            else if (powerDto.Action == PowerAction.Shutdown)
            {
                _service.Shutdown();
            }
            else
            {
                return BadRequest("Action was not valid");
            }

            return Ok();
        }

    }
}