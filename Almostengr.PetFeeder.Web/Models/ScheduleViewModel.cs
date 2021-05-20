using System;

namespace Almostengr.PetFeeder.Web.Models
{
    public class ScheduleViewModel
    {
        public int Id { get; set; }
        public DateTime ScheduledTime { get; set; }
        public bool IsActive { get; set; } = true;
    }
}