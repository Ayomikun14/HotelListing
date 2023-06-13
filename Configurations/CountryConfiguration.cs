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
    public class CountryConfiguration:IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
                builder.HasData(
                    new Country
                    {
                        Id = 1,
                        Name = "Nigeria",
                        ShortName = "NGR"
                    },
                    new Country
                    {
                        Id = 2,
                        Name = "United States Of America",
                        ShortName = "USA"
                    },
                    new Country
                    {
                         Id = 3,
                         Name = "Canada",
                         ShortName = "CAN"
                    }
            );
            
        }
    }
}
