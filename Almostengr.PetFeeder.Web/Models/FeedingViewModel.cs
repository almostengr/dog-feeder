using System;

namespace Almostengr.PetFeeder.Web.Models
{
    public class FeedingViewModel
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int ScheduleId { get; set; } = 0;
    }
}