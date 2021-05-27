namespace Almostengr.PetFeeder.Api.SignalInput
{
  private readonly GpioController _gpio;

  public SignalInputBase(ILogger<SignalInputBase> logger, GpioController gpio)
  {
    _gpio = gpio;
  }
}
