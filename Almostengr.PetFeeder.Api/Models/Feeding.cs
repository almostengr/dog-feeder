using System;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Feeding : ModelBase
    {
        public Feeding() { }

        public int ScheduleId { get; set; }
        public DateTime? Timestamp { get; set; }
        // public double Amount { get; set; }
        public int Amount { get; set; }

        internal void AssignFromDto(FeedingDto feedingDto)
        {
            Amount = feedingDto.Amount;
            Timestamp = DateTime.Now;
        }

        public FeedingDto AssignToDto()
        {
            return new FeedingDto()
            {
                ScheduleId = ScheduleId,
                Timestamp = Timestamp,
                Amount = Amount
            };
        }
        
    }
}