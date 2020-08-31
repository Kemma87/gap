using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class InsurancePolicy
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public byte CoverPeriod { get; set; }
        [Required]
        public long Cost { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserCreate { get; set; }
        [Required]
        public int RiskTypeId { get; set; }
        public RiskType RiskType { get; set; }
        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }
        [Required]
        public int CoverTypeId { get; set; }
        public CoverType CoverType { get; set; }

        [Required]
        public ICollection<PersonInsurance> Persons { get; set; }
    }
}
