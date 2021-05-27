using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Enums;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.PetFeeder.Api.Controllers
{
    public class FeedingsController : BaseController
    {
        private readonly ILogger<FeedingsController> _logger;
        private readonly IFeedingRepository _feedingRepository;
        private readonly GpioController _gpio;
        private const int FoodForwardRelay = 14;
        private const int FoodBackwardRelay = 15;

        public FeedingsController(ILogger<FeedingsController> logger, IFeedingRepository feedingRepository,
            GpioController gpio) : base(logger)
        {
            _logger = logger;
            _feedingRepository = feedingRepository;
            _gpio = gpio;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Feeding>>> GetRecentFeedingsAsync()
        {
            _logger.LogInformation("Getting recent feedings");

            var feedings = await _feedingRepository.GetRecentFeedingsAsync();
            return Ok(feedings);
        }

        [HttpGet, Route("all")]
        public async Task<ActionResult<IList<Feeding>>> GetAllFeedingsAsync()
        {
            _logger.LogInformation("Getting all feedings");

            var feedings = await _feedingRepository.GetAllFeedingsAsync();
            return Ok(feedings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feeding>> GetFeedingByIdAsync(int? id)
        {
            _logger.LogInformation("Getting single feeding");

            var feeding = await _feedingRepository.GetFeedingByIdAsync(id);

            if (feeding != null)
            {
                return Ok(feeding);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<Feeding>> CreateFeedingAsync(Feeding feeding)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            try
            {
                OpenPinsForOutput(_gpio, new Int32[] { FoodForwardRelay, FoodBackwardRelay });

                PerformFeeding(feeding); // should be done with await?

                await _feedingRepository.CreateFeedingAsync(feeding);
                await _feedingRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            ClosePins(_gpio, new Int32[] { FoodForwardRelay, FoodBackwardRelay });

            return StatusCode(201);
        }

        // private async Task PerformFeeding(Schedule schedule)
        private async Task PerformFeeding(Feeding feeding)
        {
            // Feeding feeding = new Feeding();
            // feeding.Timestamp = DateTime.Now;
            // feeding.Amount = schedule.FeedingAmount;
            // feeding.ScheduleId = schedule.Id;

            // run the motor to dispense food
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, 0.5);
            await RunMotor(MotorDirection.Backward, 0.5);
            await RunMotor(MotorDirection.Forward, feeding.Amount);
            await RunMotor(MotorDirection.Backward, 0.5);

            feeding.Timestamp = DateTime.Now;

            await _feedingRepository.CreateFeedingAsync(feeding);
            await _feedingRepository.SaveChangesAsync();
        }

        private async Task RunMotor(MotorDirection direction, double onTime)
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