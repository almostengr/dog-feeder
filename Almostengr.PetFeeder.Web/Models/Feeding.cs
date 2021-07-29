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
        public DateTime Modified { get; internal set; }

        internal void AssignFromDto(FeedingDto feedingDto)
        {
            Amount = feedingDto.Amount;
            Created = DateTime.Now;
        }

        public FeedingDto AssignToDto()
        {
            return new FeedingDto()
            {
                ScheduleId = ScheduleId,
                Created = Created,
                Amount = Amount
            };
        }

    }
}