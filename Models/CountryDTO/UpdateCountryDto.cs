using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Models.Country;
using HotelListing.Models.HotelDTO;

namespace HotelListing.Models.CountryDTO
{
    public class UpdateCountryDto: CreateCountryDto
    {
        public IList<CreateHotelDto> Hotels { get; set; }
    }
}
