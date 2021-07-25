using System;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class AlarmDto
    {
        public int AlarmId { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public bool IsActive { get; set; }
    }
}