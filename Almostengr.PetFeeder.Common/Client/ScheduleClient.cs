using System.Collections.Generic;
using System.Threading.Tasks;
using Almostengr.PetFeeder.Api.Models;
using Almostengr.PetFeeder.Common.Client.Interface;

namespace Almostengr.PetFeeder.Common.Client
{
    public class ScheduleClient : BaseClient, IScheduleClient
    {
        public Task<Schedule> CreateScheduleAsync(Schedule Schedule)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteScheduleAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Schedule>> GetActiveSchedulesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Schedule>> GetAllSchedulesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Schedule> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Schedule> UpdateScheduleAsync(Schedule Schedule)
        {
            throw new System.NotImplementedException();
        }
    }
}