using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public class SystemSetting
    {
        public SystemSetting(SystemSettingDto systemSetting)
        {
            Name = systemSetting.Name;
            Value = systemSetting.Value;
        }

        [Key]
        public string Name { get; set; }

        public string Value { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        [Required]
        public DateTime Modified { get; set; }

        // public static Expression<Func<SystemSetting, SystemSettingDto>> ToDto()
        // {
        //     return s => new SystemSettingDto
        //     {
        //         Name = s.Name,
        //         Value = s.Value,
        //         Created = s.Created,
        //         Modified = s.Modified
        //     };
        // }
    }
}