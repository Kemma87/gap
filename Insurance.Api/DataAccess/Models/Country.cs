using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
