using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Web.Models
{
    public class SettingViewModel
    {
        public SettingViewModel(SettingDto setting)
        {
            this.Key = setting.Key;
            this.Value = setting.Value;
        }

        public SettingDto FromViewModel()
        {
            return new SettingDto(){
                Key = this.Key,
                Value = this.Value
            };
        }

        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}