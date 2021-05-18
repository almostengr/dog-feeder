using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.DogFeeder.Api.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ScheduledTime { get; set; }
        public bool IsActive { get; set; } = true;
    }
}