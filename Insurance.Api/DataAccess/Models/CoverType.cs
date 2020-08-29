using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class CoverType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public int CoveringPercentage { get; set; }
    }
}
