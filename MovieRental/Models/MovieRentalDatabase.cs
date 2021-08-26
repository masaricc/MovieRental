﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRental.Models
{
    public class MovieRentalDatabase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Producer { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string Length { get; set; }

    }
}
