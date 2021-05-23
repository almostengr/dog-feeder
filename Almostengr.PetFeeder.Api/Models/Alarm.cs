using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Alarm
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public bool IsActive { get; set; }
        public DateTime? Dismissed { get; set; }
    }
}