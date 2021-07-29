using System;
using Almostengr.PetFeeder.Web.Enums;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Models
{
    public class ScheduleViewModel
    {
        public ScheduleViewModel()
        { }

        public ScheduleViewModel(ScheduleDto schedule)
        {
            this.Id = schedule.ScheduleId;
            this.ScheduledTime = schedule.ScheduledTime;
            this.IsActive = schedule.IsActive;
            this.Frequency = schedule.Frequency;
            this.IpAddress = schedule.IpAddress;
        }

        public ScheduleDto FromViewModel()
        {
            return new ScheduleDto()
            {
                ScheduleId = this.Id,
                ScheduledTime = this.ScheduledTime,
                IsActive = this.IsActive,
                Frequency = this.Frequency,
                IpAddress = this.IpAddress
            };
        }

        public int Id { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsActive { get; set; }
        public DayFrequency Frequency { get; set; }
        public string IpAddress { get; set; }
    }
}