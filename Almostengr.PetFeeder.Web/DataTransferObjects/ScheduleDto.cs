using System;
using Almostengr.PetFeeder.Web.Enums;

namespace Almostengr.PetFeeder.Web.DataTransferObjects
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsActive { get; set; } = true;
        public double FeedingAmount { get; set; }
        public DayFrequency Frequency { get; set; }
        public string IpAddress { get; set; }
        public DateTime Modified { get; internal set; }
        public DateTime Created { get; internal set; }
    }
}