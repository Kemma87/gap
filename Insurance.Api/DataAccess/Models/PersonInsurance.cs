using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class PersonInsurance
    {
        [Required]
        public int InsuranceId { get; set; }
        public InsurancePolicy Insurance { get; set; }
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
