using System;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Models
{
    public class WateringViewModel
    {
        public WateringViewModel(WateringDto watering)
        {
            this.Id = watering.WateringId;
            this.WateringTime = watering.Created;
        }

        public WateringDto FromViewModel()
        {
            return new WateringDto(){
                Created = this.WateringTime,
            };
        }

        public int Id { get; set; }
        public DateTime WateringTime { get; set; }
    }
}