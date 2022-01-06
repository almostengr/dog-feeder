using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public class Watering
    {
        [Key]
        public int WateringId { get; set; }
        
        [Required]
        public double Amount { get; set; }
    
        [Required]
        public DateTime Created { get; set; }
    }
}