using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Models
{
    public class Watering : ModelBase
    {
        [Key]
        public int WateringId { get; set; }
        
        [Required]
        public DateTime Created { get; set; }

        [Required]
        public double Amount { get; set; }

        internal void CreateFromDto(WateringDto wateringDto)
        {
            this.Created = DateTime.Now;
            this.Amount = wateringDto.Amount;
        }

        internal WateringDto AssignToDto()
        {
            return new WateringDto()
            {
                WateringId = this.WateringId,
                Created = this.Created,
                Amount = this.Amount
            };
        }
    }
}