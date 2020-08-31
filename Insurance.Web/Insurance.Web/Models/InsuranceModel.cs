using System;

namespace Insurance.Web.Models
{
    public class InsuranceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public byte CoverPeriod { get; set; }
        public long Cost { get; set; }
        public RiskTypeModel RiskType { get; set; }
        public CoverTypeModel CoverType { get; set; }
        public LocationModel Location { get; set; }
        public DateTime CreationDate { get; set; }
        public int RiskTypeId { get; set; }
        public int CoverTypeId { get; set; }
        public int LocationId { get; set; }
        public string UserCreate { get; set; }
    }
}
