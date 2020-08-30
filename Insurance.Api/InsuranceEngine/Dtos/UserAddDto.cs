using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InsuranceEngine.Dtos
{
    public class UserAddDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Username must be up to 20 chracters")]
        public string Username { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "You must specify password be between 8 and 15 characters")]
        public string Password { get; set; }
        [Required]
        public ICollection<int> Roles { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "First name must be up to 20 chracters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Last name must be up to 20 chracters")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public int GenderId { get; set; }
    }
}
