using System;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Web.Models
{
    public class WateringViewModel
    {
        public WateringViewModel(WateringDto watering)
        {
            this.Id = watering.WateringId;
            this.WateringTime = watering.Timestamp;
        }

        public WateringDto FromViewModel()
        {
            return new WateringDto(){
                Timestamp = this.WateringTime,
            };
        }

        public int Id { get; set; }
        public DateTime WateringTime { get; set; }
    }
}