using System;

namespace Almostengr.PetFeeder.Web.DataTransferObjects
{
    public class AlarmDto : BaseDto
    {
        public int AlarmId { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public bool IsActive { get; set; }
    }
}