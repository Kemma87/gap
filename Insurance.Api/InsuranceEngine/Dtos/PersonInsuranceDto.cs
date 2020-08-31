using System;

namespace InsuranceEngine.Dtos
{
    public class PersonInsuranceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public byte CoverPeriod { get; set; }
        public long Cost { get; set; }
        public int RiskTypeId { get; set; }
    }
}
