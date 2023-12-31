﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models.HotelDTO
{
    public class CreateHotelDto
    {
        [Required(ErrorMessage = "Hotel Name is required")]
        [StringLength(maximumLength:150, ErrorMessage = "Country Name Is Too Long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(maximumLength: 150, ErrorMessage ="Address Too Long")]
        public string Address { get; set; }
        [Required]
        [Range(1,5)]
        public double Rating { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
