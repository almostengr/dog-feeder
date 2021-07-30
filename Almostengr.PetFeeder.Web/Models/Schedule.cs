using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Web.DataTransferObjects;
using Almostengr.PetFeeder.Web.Enums;

namespace Almostengr.PetFeeder.Web.Models
{
    public class Schedule : ModelBase
    {
        [Key]
        public int ScheduleId {get;set;}

        [Required]
        public DateTime ScheduledTime { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
        
        [Required]
        public double FeedingAmount { get; set; }

        [Required]
        public DayFrequency Frequency { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified {get;set;}

        internal ScheduleDto AssignToDto()
        {
            return new ScheduleDto()
            {
                ScheduleId = this.ScheduleId,
                ScheduledTime = this.ScheduledTime,
                IsActive = this.IsActive,
                FeedingAmount = this.FeedingAmount,
                Frequency = this.Frequency,
                Created = this.Created,
                Modified = this.Modified,
            };
        }

        internal void CreateFromDto(ScheduleDto scheduleDto)
        {
            this.Created = DateTime.Now;
            this.ScheduledTime = scheduleDto.ScheduledTime;
            this.IsActive = scheduleDto.IsActive;
            this.FeedingAmount = scheduleDto.FeedingAmount;
            this.Frequency = scheduleDto.Frequency;
            this.Modified = DateTime.Now;
        }

        internal void UpdateFromDto(ScheduleDto scheduleDto)
        {
            this.ScheduledTime = scheduleDto.ScheduledTime;
            this.IsActive = scheduleDto.IsActive;
            this.FeedingAmount = scheduleDto.FeedingAmount;
            this.Frequency = scheduleDto.Frequency;
            this.Modified = DateTime.Now;
        }

    }
}