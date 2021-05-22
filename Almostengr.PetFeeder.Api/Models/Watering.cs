using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Watering
    {
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
    }
}