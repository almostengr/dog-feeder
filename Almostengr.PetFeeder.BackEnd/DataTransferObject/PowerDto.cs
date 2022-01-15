using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.DataTransferObjects
{
    public class PowerDto : BaseDto
    {
        [Required]
        public string Action { get; set; }
    }
}