namespace Almostengr.PetFeeder.Api.Relay
{
  public class FeedingRelay : RelayBase, IFeedingRelay
  {
    private readonly ILogger<FeedingRelay> _logger;
    private readonly GpioController _gpio;
  
    public FeedingRelay(ILogger<FeedingRelay> logger, GpioController gpio) : base()
    {
        _logger = logger;
        _gpio = gpio;
    
        public async Task<Feeding> PerformFeeding(Feeding feeding)
        {
            // run the motor to dispense food
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, 0.5);
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, feeding.Amount);
            await RunMotor(MotorDirection.Backward, 0.5);

            feeding.Timestamp = DateTime.Now;
            
            return feeding;
        }

        public async Task RunMotor(MotorDirection direction, double onTime)
        {
            switch (direction)
            {
                case MotorDirection.Forward:
                    _gpio.Write(FoodForwardRelay, GpioOn);
                    _gpio.Write(FoodBackwardRelay, GpioOff);
                    break;

                case MotorDirection.Backward:
                    _gpio.Write(FoodForwardRelay, GpioOff);
                    _gpio.Write(FoodBackwardRelay, GpioOn);
                    break;

                default:
                    break;
            }

            await Task.Delay(TimeSpan.FromSeconds(onTime));

            _gpio.Write(FoodForwardRelay, GpioOff);
            _gpio.Write(FoodBackwardRelay, GpioOff);
        }
    }
  }
}
