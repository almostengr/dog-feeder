using System;
using Almostengr.PetFeeder.Api.Enums;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsActive { get; set; } = true;
        public int FeedingAmount { get; set; }
        public DayFrequency Frequency { get; set; }
        public string IpAddress { get; set; }
    }
}