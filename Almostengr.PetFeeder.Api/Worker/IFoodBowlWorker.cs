using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Enums;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Api.Worker
{
    public interface IFoodBowlWorker
    {
        bool DoesScheduleFrequencyMatchDayOfWeek(DayFrequency frequency);
        Schedule IsTimeToFeed(List<Schedule> schedules);
        Task PerformFeeding(Schedule schedule);
        Task StartAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}