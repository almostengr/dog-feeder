using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Models
{
    public abstract class ModelBase
    {
        [Key]
        public int Id { get; set; }
    }
}