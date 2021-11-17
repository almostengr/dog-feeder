using System;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.DataTransferObjects
{
    public class WateringDto : BaseDto
    {
        public DateTime Created { get; set; }
        public double Amount { get; internal set; }
    }
}