using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.DogFeeder.Models
{
    public class Feeding
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime Timestamp { get; set; }
    }
}