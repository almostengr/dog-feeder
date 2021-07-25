using System;
using Almostengr.PetFeeder.Api.Enums;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Web.Models
{
    public class ScheduleViewModel
    {
        public ScheduleViewModel()
        { }

        public ScheduleViewModel(Schedule schedule)
        {
            this.Id = schedule.Id;
            this.ScheduledTime = schedule.ScheduledTime;
            this.IsActive = schedule.IsActive;
            this.Frequency = schedule.Frequency;
            this.IpAddress = schedule.IpAddress;
        }

        public Schedule FromViewModel()
        {
            return new Schedule()
            {
                Id = this.Id,
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