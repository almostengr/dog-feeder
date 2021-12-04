using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class SystemSettingDto
    {
        [Required]
        public int SettingId { get; set; }
        [Required]
        public SettingName SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}