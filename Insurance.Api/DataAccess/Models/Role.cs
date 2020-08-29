using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string RoleName { get; set; }
        [Required]
        public IList<UserRoles> Users { get; set; }
    }
}
