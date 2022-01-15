using System;
using System.ComponentModel.DataAnnotations;
using Almostengr.PetFeeder.Common.DataTransferObject;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public class Feeding
    {
        public Feeding() 
        {
        }
        
        public Feeding(FeedingDto feedingDto)
        {
            Amount = feedingDto.Amount;
            FeedingType = (int)feedingDto.FeedingType;
        }

        [Key]
        public int FeedingId { get; set; }

        [Required]
        public int FeedingType { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}