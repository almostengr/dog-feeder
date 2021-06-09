using System;
using Almostengr.PetFeeder.Api.Enums;

namespace Almostengr.PetFeeder.Web.Models
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsActive { get; set; }
        public DayFrequency Frequency { get; set; }
        public string IpAddress { get; set; }
    }
}