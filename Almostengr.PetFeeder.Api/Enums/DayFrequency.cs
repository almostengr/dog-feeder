using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Api.Enums
{
    public enum DayFrequency
    {
        [Display(Name = "None (Off)")]
        None,
        Once,
        Daily,
        Weekday,
        Weekend
    }
}
