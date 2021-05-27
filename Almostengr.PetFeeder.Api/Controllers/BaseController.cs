
using System.Device.Gpio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        internal PinValue GpioOn = PinValue.High;
        internal PinValue GpioOff = PinValue.Low;

        protected BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        internal void OpenPinsForOutput(GpioController gpio, int[] pins)
        {
            for(int i = 0; i < pins.Length; i++)
            {
                gpio.OpenPin(pins[i], PinMode.Output);
            }
        }

        internal void OpenPinsForInput(GpioController gpio, int[] pins)
        {
            for(int i = 0; i < pins.Length; i++)
            {
                gpio.OpenPin(pins[i], PinMode.Input);
            }
        }

        internal void ClosePins(GpioController gpio, int[] pins)
        {
            for(int i = 0; i < pins.Length; i++)
            {
                gpio.ClosePin(pins[i]);
            }
        }
    }
}