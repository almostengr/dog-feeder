using System;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Web.Models
{
    public class FeedingViewModel
    {
        public FeedingViewModel(Feeding feeding)
        {
            this.Id = feeding.Id;
            this.Timestamp = feeding.Timestamp;
            this.ScheduleId = feeding.ScheduleId;
        }

        public Feeding FromViewModel()
        {
            return new Feeding() {
                Id = this.Id,
                Timestamp = this.Timestamp,
                ScheduleId = this.ScheduleId
            };
        }

        public int Id { get; set; }
        public DateTime? Timestamp { get; set; } = DateTime.Now;
        public int ScheduleId { get; set; } = 0;
    }
}