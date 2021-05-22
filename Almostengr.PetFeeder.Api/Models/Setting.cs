using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Setting
    {
        [Key]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
        public string Type { get; set; }
    }
}