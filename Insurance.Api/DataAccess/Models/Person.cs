using System;

namespace DataAccess.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Address { get; set; }
        public Country Country { get; set; }
        public Gender Gender { get; set; }
    }
}
