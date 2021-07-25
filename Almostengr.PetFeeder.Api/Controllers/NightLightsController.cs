using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Relays;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    public class NightLightsController : BaseController
    {
        private readonly INightLightRelay _nightLightRelay;

        public NightLightsController(ILogger<BaseController> logger, INightLightRelay nightLightRelay) : base(logger)
        {
            _nightLightRelay = nightLightRelay;
        }

        [HttpPost]
        public async Task<ActionResult<NightLight>> CreateNightLightAsync([FromBody] NightLight nightLight)
        {
            if (nightLight.LightOn)
            {
                await _nightLightRelay.NightLightOnAsync();
            }
            else {
                await _nightLightRelay.NightLightOffAsync();
            }

            return Ok();
        }
    }
}