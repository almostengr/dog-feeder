using System;
using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Web.Models
{
    public class WateringViewModel
    {
        public WateringViewModel(Watering watering)
        {
            this.Id = watering.Id;
            this.WateringTime = watering.Timestamp;
        }

        public Watering FromViewModel()
        {
            return new Watering(){
                Timestamp = this.WateringTime,
            };
        }

        public int Id { get; set; }
        public DateTime WateringTime { get; set; }
    }
}