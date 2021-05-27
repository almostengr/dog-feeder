using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Feeding
    {
        public Feeding() { }

        [Key]
        public int Id { get; set; }

        public DateTime? Timestamp { get; set; }
        public int ScheduleId { get; set; }
        // public double Amount { get; set; }
        public int Amount { get; set; }
    }
}