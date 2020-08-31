using System.Collections.Generic;

namespace Insurance.Web.Models
{
    public class PersonInsuranceModel
    {
        public int PersonId { get; set; }
        public int InsuranceId { get; set; }
        public ICollection<InsuranceModel> Insurances { get; set; }
    }
}
