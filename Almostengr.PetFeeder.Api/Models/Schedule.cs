using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Api.Enums;

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
    }
}