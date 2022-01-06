using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.BackEnd.Enums;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public class Schedule
    {
        public Schedule()
        {
        }

        public Schedule(ScheduleDto scheduleDto)
        {
            ScheduleId = scheduleDto.ScheduleId;
            ScheduledTime = scheduleDto.ScheduledTime;
            FeedingAmount = scheduleDto.FeedingAmount;
            IsActive = scheduleDto.IsActive;
            ScheduleType = (int)scheduleDto.ScheduleType;
        }

        [Key]
        public int ScheduleId { get; set; }
        
        public DateTime ScheduledTime { get; set; }
        
        public double FeedingAmount { get; set; } = 0;
        
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }
        
        public int ScheduleType { get; set; }
    }
}