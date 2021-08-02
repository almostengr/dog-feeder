using System;

namespace Almostengr.PetFeeder.Web.DataTransferObjects
{
    public class WateringDto : BaseDto
    {
        public int WateringId { get; set; }
        public DateTime Created { get; set; }
        public double Amount { get; internal set; }
    }
}