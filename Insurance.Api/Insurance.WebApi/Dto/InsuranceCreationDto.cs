using System;
using System.ComponentModel.DataAnnotations;

namespace Insurance.WebApi.Dto
{
    public class InsuranceCreationDto
    {
        public InsuranceCreationDto()
        {
            CreationDate = DateTime.UtcNow;
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public byte ConverPeriod { get; set; }

        [Required]
        public long Cost { get; set; }

        [Required]
        public int RiskType { get; set; }

        [Required]
        public int CoverType { get; set; }

        [Required]
        public int Location { get; set; }

        public DateTime CreationDate { get; set; }
        public string UserId { get; set; }
    }
}
