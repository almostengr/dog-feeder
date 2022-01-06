using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.BackEnd.Enums;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class FeedingDto : BaseDto
    {
        public int FeedingId { get; set; }

        [Required]
        public FeedingType FeedingType { get; set; }
        public DateTime Created { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}