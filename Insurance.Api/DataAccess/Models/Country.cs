﻿using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
