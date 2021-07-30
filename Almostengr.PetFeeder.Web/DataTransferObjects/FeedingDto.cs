using System;

namespace Almostengr.PetFeeder.Web.DataTransferObjects
{
    public class FeedingDto
    {
        public int FeedingId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime? Created { get; set; }
        public double Amount { get; set; }
        public string WasScheduled { get; set; }
        public DateTime Modified { get; internal set; }
    }
}