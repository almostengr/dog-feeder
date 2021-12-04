using System;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.DataTransferObjects
{
    public class WaterBowlDto : BaseDto
    {
        public int WateringId { get; set; }
        public DateTime Created { get; set; }
        public double Amount { get; set; }
    }
}