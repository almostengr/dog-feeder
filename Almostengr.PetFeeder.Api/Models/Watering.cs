using System;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Watering : ModelBase
    {
        public DateTime Timestamp { get; set; }

        internal void AssignFromDto(WateringDto wateringDto)
        {
            Timestamp = DateTime.Now;
        }

        internal WateringDto AssignToDto()
        {
            return new WateringDto()
            {
                WateringId = this.Id,
                Timestamp = Timestamp
            };
        }
    }
}