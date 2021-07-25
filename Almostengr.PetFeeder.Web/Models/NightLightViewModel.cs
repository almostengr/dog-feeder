using Almostengr.PetFeeder.Api.Models;

public class NightLightViewModel
{
    public NightLightViewModel(bool lighton)
    {
        this.LightOn = lighton;
    }

    public NightLight FromViewModel()
    {
        return new NightLight()
        {
            LightOn = this.LightOn
        };
    }

    public bool LightOn { get; set; }
}