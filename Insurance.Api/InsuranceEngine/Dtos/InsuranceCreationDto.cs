using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceEngine.Dtos
{
    public class InsuranceCreationDto
    {
        public InsuranceCreationDto()
        {
            CreationDate = DateTime.UtcNow;
        }

        [Required]
        [MaxLength(30, ErrorMessage = "Insurance policy name must be up to 30 chracters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "Insurance policy description must be up to 300 chracters")]
        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public byte ConverPeriod { get; set; }

        [Required]
        public long Cost { get; set; }

        [Required]
        public int RiskTypeId { get; set; }

        [Required]
        public int CoverTypeId { get; set; }

        [Required]
        public int LocationId { get; set; }

        public DateTime CreationDate { get; set; }
        public string UserCreate { get; set; }
    }
}
