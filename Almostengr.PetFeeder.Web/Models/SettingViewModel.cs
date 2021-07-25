using Almostengr.PetFeeder.Api.Models;

namespace Almostengr.PetFeeder.Web.Models
{
    public class SettingViewModel
    {
        public SettingViewModel(Setting setting)
        {
            this.Id = setting.Id;
            this.Key = setting.Key;
            this.Value = setting.Value;
        }

        public Setting FromViewModel()
        {
            return new Setting(){
                Id = this.Id,
                Key = this.Key,
                Value = this.Value
            };
        }

        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}