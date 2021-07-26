using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.Common.Enums;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Schedule : ModelBase
    {
        [Required]
        public DateTime ScheduledTime { get; set; }
        
        public bool IsActive { get; set; } = true;
        public int FeedingAmount { get; set; }
        // public double FeedingAmount { get; set; }
        public DayFrequency Frequency { get; set; }
        public string IpAddress { get; set; }

        internal ScheduleDto AssignToDto()
        {
            return new ScheduleDto()
            {
                ScheduleId = this.Id,
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