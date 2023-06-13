using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext:IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<Country>().HasData(
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

            builder.Entity<Hotel>().HasData(
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
