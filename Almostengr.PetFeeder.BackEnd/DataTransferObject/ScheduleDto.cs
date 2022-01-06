using System;
using Almostengr.PetFeeder.BackEnd.Enums;
using Almostengr.PetFeeder.BackEnd.Models;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class ScheduleDto : BaseDto
    {
        public ScheduleDto(Schedule schedule)
        {
            ScheduleId = schedule.ScheduleId;
            ScheduledTime = schedule.ScheduledTime;
            FeedingAmount = schedule.FeedingAmount;
            IsActive = schedule.IsActive;
            ScheduleType = (ScheduleType)schedule.ScheduleType;
            Created = schedule.Created;
            Modified = schedule.Modified;
        }

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