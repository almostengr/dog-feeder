using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public static class ModelExtensions
    {
        public static SystemSettingDto ToSystemSettingDto(this SystemSetting systemSetting)
        {
            return new SystemSettingDto
            {
                Name = systemSetting.Name,
                Value = systemSetting.Value,
                Created = systemSetting.Created,
                Modified = systemSetting.Modified
            };
        }

    }
}