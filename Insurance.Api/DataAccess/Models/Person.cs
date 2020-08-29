using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime Modified { get; set; }
        public string Address { get; set; }
        [Required]
        public Country Country { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}
