using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Api.Models
{
    public class Setting : ModelBase
    {
        [Required]
        public string Key { get; set; }
        
        [Required]
        public string Value { get; set; }

        public string Type { get; set; }

        internal SettingDto AssignToDto()
        {
            return new SettingDto()
            {
                Key = this.Key,
                Value = this.Value,
            };
        }

        internal void AssignFromDto(SettingDto settingDto)
        {
            this.Key = settingDto.Key;
            this.Value = settingDto.Value;
        }
    }
}