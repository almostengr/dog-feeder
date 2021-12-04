using Almostengr.PetFeeder.Common;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public class SystemSetting
    {
        public int Id { get; set; }
        public SettingName Name { get; set; }
        public string Value { get; set; }
    }
}