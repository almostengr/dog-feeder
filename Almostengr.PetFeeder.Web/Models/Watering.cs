using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Models
{
    public class Watering : ModelBase
    {
        [Key]
        public int WateringId { get; set; }
        
        public DateTime Created { get; set; }

        internal void AssignFromDto(WateringDto wateringDto)
        {
            Created = DateTime.Now;
        }

        internal WateringDto AssignToDto()
        {
            return new WateringDto()
            {
                WateringId = this.WateringId,
                Created = this.Created
            };
        }
    }
}