using System;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class FeedingDto : BaseDto
    {
        public DateTime Created { get; set; }
        public double Amount { get; set; }
    }
}