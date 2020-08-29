using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class RiskType
    {
        public int Id { get; set; }
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
