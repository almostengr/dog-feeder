using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
    }
}