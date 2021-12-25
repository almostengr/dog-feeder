using System;
using Almostengr.PetFeeder.Common.Enum;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class ScheduleDto : BaseDto
    {
        public int ScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public double FeedingAmount { get; set; }
        public FeedingFrequency FeedingFrequency { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}