using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Eko Hotel",
                    Address = "Victoria Island Lagos",
                    CountryId = 1,
                    Rating = 4.5,
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Marriott Hilton Head Resort & Spa",
                    Address = "One Hotel Circle, Hilton Head Island, SC 29928, United States",
                    CountryId = 2,
                    Rating = 4.0
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Hygie Hotel",
                    Address = "401 Notre-Dame St. East, Montreal, Quebec H2Y 1C9, Canada",
                    CountryId = 3,
                    Rating = 3.6
                }
                );
        }
    }
}
