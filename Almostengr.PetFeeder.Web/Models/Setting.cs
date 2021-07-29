using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Models
{
    public class Setting : ModelBase
    {
        [Key]
        public int SettingId { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

        public string Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

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
            this.Modified = DateTime.Now;
        }
    }
}