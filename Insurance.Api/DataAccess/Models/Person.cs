using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime Modified { get; set; }
        public string Address { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [Required]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
    }
}
