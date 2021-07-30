using System;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Models
{
    public class Feeding : ModelBase
    {
        public Feeding() { }

        public int FeedingId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime? Created { get; set; }
        public double Amount { get; set; }

        internal void CreateFromDto(FeedingDto feedingDto)
        {
            this.ScheduleId = feedingDto.ScheduleId;
            this.Created = DateTime.Now;
            this.Amount = feedingDto.Amount;
        }

        public FeedingDto AssignToDto()
        {
            return new FeedingDto()
            {
                FeedingId = this.FeedingId,
                ScheduleId = this.ScheduleId,
                Created = this.Created,
                Amount = this.Amount,
                WasScheduled = this.ScheduleId > 0 ? "Yes" : "No"
            };
        }

    }
}