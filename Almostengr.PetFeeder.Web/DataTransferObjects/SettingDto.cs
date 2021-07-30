using System;

namespace Almostengr.PetFeeder.Web.DataTransferObjects
{
    public class SettingDto
    {
        public string Value { get; set; }
        public string Key { get; set; }
        public DateTime Modified { get; internal set; }
        public DateTime Created { get; internal set; }
    }
}