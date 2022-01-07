using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.BackEnd.Enums;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class ScheduleDto : BaseDto
    {
        public int ScheduleId { get; set; }

        [Required]
        public DateTime ScheduledTime { get; set; }

        [Required]
        [Range(0,10)]
        public double FeedingAmount { get; set; }

        [Required]
        public FeedingFrequency FeedingFrequency { get; set; }

        public bool IsActive { get; set; } = true;
    
        [Range(1,2, ErrorMessage = "Invalid Schedule Type")]
        public ScheduleType ScheduleType { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}