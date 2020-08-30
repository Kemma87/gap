using DataAccess.Models;
using System;

namespace Insurance.WebApi.Dto
{
    public class InsuranceReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public byte ConverPeriod { get; set; }
        public long Cost { get; set; }
        public RiskType RiskType { get; set; }
        public CoverType CoverType { get; set; }
        public Location Location { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserCreate { get; set; }
    }
}
