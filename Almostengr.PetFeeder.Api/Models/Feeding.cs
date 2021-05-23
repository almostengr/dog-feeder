using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Feeding
    {
        public Feeding() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
        public int ScheduleId { get; set; }
        public double Amount { get; set; }
    }
}