using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.DataTransferObjects;
using Almostengr.PetFeeder.BackEnd.Relays;
using Almostengr.PetFeeder.BackEnd.Relays.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.BackEnd.Controllers.Api
{
    public class NightLightsController : BaseApiController
    {
        private readonly INightLightRelay _nightLightRelay;

        public NightLightsController(ILogger<BaseApiController> logger, INightLightRelay nightLightRelay) : base(logger)
        {
            _nightLightRelay = nightLightRelay;
        }

        // POST /api/nightlights
        [HttpPost]
        public async Task<ActionResult> CreateNightLightAsync([FromBody] NightLightDto nightLightDto)
        {
            if (nightLightDto.LightOn)
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