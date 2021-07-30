using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Web.DataTransferObjects;

namespace Almostengr.PetFeeder.Web.Models
{
    public class Alarm : ModelBase
    {
        public int AlarmId { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required, MaxLength(50, ErrorMessage = "Type must be less than 50 characters")]
        public string Type { get; set; }

        [MaxLength(500, ErrorMessage = "Message must be less than 500 characters")]
        public string Message { get; set; }

        public bool IsActive { get; set; } = true;
        public DateTime Modified { get; set; }

        internal void CreateFromDto(AlarmDto alarmDto)
        {
            this.Created = DateTime.Now;
            this.Type = alarmDto.Type;
            this.Message = alarmDto.Message;
            this.IsActive = true;
            this.Modified = DateTime.Now;
        }

        internal void UpdateFromDto(AlarmDto alarmDto)
        {
            this.Type = alarmDto.Type;
            this.Message = alarmDto.Message;
            this.IsActive = alarmDto.IsActive;
            this.Modified = DateTime.Now;
        }

        public AlarmDto AssignToDto()
        {
            return new AlarmDto()
            {
                AlarmId = this.AlarmId,
                Created = this.Created,
                Type = this.Type,
                Message = this.Message,
                IsActive = this.IsActive
            };
        }
    }
}