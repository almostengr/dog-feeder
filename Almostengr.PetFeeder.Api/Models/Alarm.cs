using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Alarm : ModelBase
    {
        public DateTime Created { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public string Message { get; set; }
        public bool IsActive { get; set; } = true;
    }
}