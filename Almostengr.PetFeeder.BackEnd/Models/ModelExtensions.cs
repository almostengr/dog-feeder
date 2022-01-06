using Almostengr.PetFeeder.BackEnd.Enums;
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

        public static ScheduleDto ToScheduleDto(this Schedule schedule)
        {
            return new ScheduleDto
            {
                ScheduleId = schedule.ScheduleId,
                ScheduledTime = schedule.ScheduledTime,
                FeedingAmount = schedule.FeedingAmount,
                IsActive = schedule.IsActive,
                Created = schedule.Created,
                Modified = schedule.Modified,
                ScheduleType = (ScheduleType)schedule.ScheduleType
            };
        }

        public static FeedingDto ToFeedingDto(this Feeding feeding)
        {
            return new FeedingDto
            {
                FeedingId = feeding.FeedingId,
                Amount = feeding.Amount,
                Created = feeding.Created,
            };
        }

    }
}