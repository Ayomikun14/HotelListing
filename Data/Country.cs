using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Data
{
    public class Country
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Country name is required")]
        public string Name { get; set; }
        [StringLength(3, MinimumLength = 2)]
        public string ShortName { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
    }
}
