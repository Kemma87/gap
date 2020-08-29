using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Gender
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
    }
}
