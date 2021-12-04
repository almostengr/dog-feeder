using System;
using System.Linq.Expressions;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public double FeedingAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }


        public static Expression<Func<Schedule,ScheduleDto>> ToDto()
        {
            return s => new ScheduleDto{
                ScheduleId = s.ScheduleId,
                StartTime = s.ScheduledTime,
                FeedingAmount = s.FeedingAmount,
                IsActive = s.IsActive,
                Created = s.Created,
                Modified = s.Modified
            };
        }
    }
}