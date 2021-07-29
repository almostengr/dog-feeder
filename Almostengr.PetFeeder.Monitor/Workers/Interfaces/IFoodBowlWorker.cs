using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Web.Enums;
using Almostengr.PetFeeder.Web.DataTransferObject;

namespace Almostengr.PetFeeder.Monitor.Workers
{
    public interface IFoodBowlWorker : IBaseWorker
    {
        bool DoesScheduleFrequencyMatchDayOfWeek(DayFrequency frequency);
        ScheduleDto IsTimeToFeed(IList<ScheduleDto> schedules);
        Task DoFeedPetAsync(ScheduleDto schedule);
    }
}