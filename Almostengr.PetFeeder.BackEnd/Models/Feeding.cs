using System;

namespace Almostengr.PetFeeer.Web.Models
{
    public class Feeding
    {
        public int FeedingId { get; set; }
        public double Amount { get; set; }
        public string IpAddress { get; set; }
        public DateTime Created { get; set; }
    }
}