using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime LastActive { get; set; }
        [Required]
        public Person Person { get; set; }
        [Required]
        public ICollection<UserRoles> Roles { get; set; }
    }
}
