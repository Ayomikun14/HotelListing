using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Models.HotelDTO;

namespace HotelListing.Models.Country
{
    public class CountryDto: CreateCountryDto
    {
        //Dto is used to add validation
        public int Id { get; set; }
        public ICollection<HotelDto> Hotels { get; set; }
    }
}
