using System;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class FeedingDto
    {
        public int FeedingId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime? Timestamp { get; set; }
        public int Amount { get; set; }
    }
}