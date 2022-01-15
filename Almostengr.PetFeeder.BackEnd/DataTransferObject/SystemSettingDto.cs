using System;
using System.ComponentModel.DataAnnotations;

namespace Almostengr.PetFeeder.Common.DataTransferObject
{
    public class SystemSettingDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}