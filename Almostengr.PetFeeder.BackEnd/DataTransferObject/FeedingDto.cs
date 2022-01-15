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

        [Required]
        [Range(0.1, 15, ErrorMessage = "Amount must be between 0.1 and 15")]
        public double Amount { get; set; }

        public DateTime Created { get; set; }
    }
}