using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Enums;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Worker.Workers
{
    public interface IFoodBowlWorker : IBaseWorker
    {
        bool DoesScheduleFrequencyMatchDayOfWeek(DayFrequency frequency);
        Schedule IsTimeToFeed(IList<Schedule> schedules);
        Task DoFeedPetAsync(Schedule schedule);
    }
}