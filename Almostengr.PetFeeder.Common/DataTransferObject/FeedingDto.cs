using System;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class FeedingDto : BaseDto
    {
        public int FeedingId { get; set; }
        public DateTime Created { get; set; }
        public double Amount { get; set; }
        public bool ScheduledFeeding { get; set; }
    }
}