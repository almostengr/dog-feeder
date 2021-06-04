using System;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Feeding : ModelBase
    {
        public Feeding() { }

        public DateTime? Timestamp { get; set; }
        public int ScheduleId { get; set; }
        // public double Amount { get; set; }
        public int Amount { get; set; }
    }
}