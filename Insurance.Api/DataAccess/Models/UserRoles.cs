using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class UserRoles
    {
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
