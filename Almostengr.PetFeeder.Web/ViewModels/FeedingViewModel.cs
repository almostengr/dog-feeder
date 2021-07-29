using System;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Models
{
    public class FeedingViewModel
    {
        public FeedingViewModel(FeedingDto feeding)
        {
            this.Id = feeding.FeedingId;
            this.Timestamp = feeding.Created;
            this.ScheduleId = feeding.ScheduleId;
        }

        public FeedingDto FromViewModel()
        {
            return new FeedingDto() {
                FeedingId = this.Id,
                Created = this.Timestamp,
                ScheduleId = this.ScheduleId
            };
        }

        public int Id { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.Now;
        public int ScheduleId { get; set; } = 0;
    }
}