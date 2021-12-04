using System;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public class Watering
    {
        public int WateringId { get; set; }
        public double Amount { get; set; }
        public DateTime Created { get; set; }
        public string IpAddress { get; set; }
    }
}