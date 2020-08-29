using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Gender
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
