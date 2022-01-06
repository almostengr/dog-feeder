using System;
using Almostengr.PetFeeder.BackEnd.Enums;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class ScheduleDto : BaseDto
    {
        public int ScheduleId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public double FeedingAmount { get; set; }
        public FeedingFrequency FeedingFrequency { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public ScheduleType ScheduleType { get; set; }
    }
}