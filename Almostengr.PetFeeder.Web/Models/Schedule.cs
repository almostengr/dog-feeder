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

        public bool IsActive { get; set; } = true;
        public double FeedingAmount { get; set; }
        public DayFrequency Frequency { get; set; }
        public string IpAddress { get; set; }
        public DateTime Created { get; set; }

        internal ScheduleDto AssignToDto()
        {
            return new ScheduleDto()
            {
                ScheduleId = this.ScheduleId,
                ScheduledTime = this.ScheduledTime,
                IsActive = this.IsActive,
                FeedingAmount = this.FeedingAmount,
                Frequency = this.Frequency,
                IpAddress = this.IpAddress,
            };
        }

        internal void AssignFromDto(ScheduleDto scheduleDto)
        {
            this.ScheduledTime = scheduleDto.ScheduledTime;
            this.IsActive = scheduleDto.IsActive;
            this.FeedingAmount = scheduleDto.FeedingAmount;
            this.Frequency = scheduleDto.Frequency;
            this.IpAddress = scheduleDto.IpAddress;
        }
    }
}