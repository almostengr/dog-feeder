using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.DogFeeder.Api.Models
{
    public class Feeding
    {
        public Feeding() {}
        
        public Feeding (int scheduleId)
        {
            ScheduleId = scheduleId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int ScheduleId { get; set; }
    }
}