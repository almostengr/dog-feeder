using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime ScheduledTime { get; set; }
        public bool IsActive { get; set; } = true;
        public int? UserId { get; set; }
    }
}