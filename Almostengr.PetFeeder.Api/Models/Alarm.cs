using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Alarm : ModelBase
    {
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required, MaxLength(50, ErrorMessage = "Type must be less than 50 characters")]
        public string Type { get; set; }
        

        [MaxLength(500, ErrorMessage = "Message must be less than 500 characters")]
        public string Message { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}