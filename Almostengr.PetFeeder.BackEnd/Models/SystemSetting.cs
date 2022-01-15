using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public class SystemSetting
    {
        public SystemSetting()
        {
        }

        public SystemSetting(SystemSettingDto systemSetting)
        {
            Name = systemSetting.Name;
            Value = systemSetting.Value;
            Description = systemSetting.Description;
        }

        [Key]
        public string Name { get; set; }

        public string Value { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        [Required]
        public DateTime Modified { get; set; }
        public string Description { get; set; }
    }
}