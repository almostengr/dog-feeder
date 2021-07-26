using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Common.Enums;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Monitor.Workers
{
    public interface IFoodBowlWorker : IBaseWorker
    {
        bool DoesScheduleFrequencyMatchDayOfWeek(DayFrequency frequency);
        ScheduleDto IsTimeToFeed(IList<ScheduleDto> schedules);
        Task DoFeedPetAsync(ScheduleDto schedule);
    }
}