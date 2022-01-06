using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Almostengr.PetFeeder.Common.DataTransferObject;
using Almostengr.PetFeeder.BackEnd.Enums;

namespace Almostengr.PetFeeder.BackEnd.Models
{
    public class Feeding
    {
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

        // public static Expression<Func<Feeding, FeedingDto>> ToDto()
        // {
        //     return f => new FeedingDto
        //     {
        //         FeedingId = f.FeedingId,
        //         FeedingType = (FeedingType)f.FeedingType,
        //         Amount = f.Amount,
        //         Created = f.Created
        //     };
        // }
    }
}