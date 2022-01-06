using System;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class SystemSettingDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}