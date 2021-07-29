using Almostengr.PetFeeder.Web.DataTransferObjects;

public class NightLightViewModel
{
    public NightLightViewModel(bool lighton)
    {
        this.LightOn = lighton;
    }

    public NightLightDto FromViewModel()
    {
        return new NightLightDto()
        {
            LightOn = this.LightOn
        };
    }

    public bool LightOn { get; set; }
}