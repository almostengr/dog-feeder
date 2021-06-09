using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Relays;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    public class NightLightController : BaseController
    {
        private readonly INightLightRelay _relay;

        public NightLightController(ILogger<BaseController> logger, INightLightRelay relay) : base(logger)
        {
            _relay = relay;
        }

        [HttpPost("on")]
        public async Task<ActionResult> TurnOnLight()
        {
            await _relay.NightLightOnAsync();
            return Ok();
        }

        [HttpPost("off")]
        public async Task<ActionResult> TurnOffLight()
        {
            await _relay.NightLightOffAsync();
            return Ok();
        }
    }
}