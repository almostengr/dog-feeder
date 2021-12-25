using System;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public class SystemSetting
    {
        public int SystemSettingId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}