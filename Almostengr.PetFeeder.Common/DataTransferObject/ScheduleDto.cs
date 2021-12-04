using System;
using System.Linq.Expressions;
using Almostengr.PetFeeder.BackEnd.Models;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class ScheduleDto : BaseDto
    {
        public int ScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public double FeedingAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}