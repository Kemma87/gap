using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
