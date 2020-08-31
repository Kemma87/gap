using System;

namespace InsuranceEngine.Dtos
{
    public class InsuranceUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public byte CoverPeriod { get; set; }
        public long Cost { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserCreate { get; set; }
        public int RiskTypeId { get; set; }
        public int LocationId { get; set; }
        public int CoverTypeId { get; set; }
    }
}
