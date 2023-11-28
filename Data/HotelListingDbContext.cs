using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Great Britain",
                    ShortName = "GB",
                },
                new Country
                {
                    Id = 2,
                    Name = "Belarus",
                    ShortName = "BY",
                },
                new Country
                {
                    Id = 3,
                    Name = "Poland",
                    ShortName = "PL",
                },
                new Country
                {
                    Id = 4,
                    Name = "United States",
                    ShortName = "US",
                }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Royal Palace",
                    Address = "London",
                    CountryId = 1,
                    Rating = 4.99
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Scottish Adventure Resort",
                    Address = "Glasgow",
                    CountryId = 1,
                    Rating = 4.85
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Gastinitza Tourist",
                    Address = "Minsk",
                    CountryId = 2,
                    Rating = 4.65
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Village hills appointment",
                    Address = "Cherven",
                    CountryId = 2,
                    Rating = 4.34
                },
                new Hotel
                {
                    Id = 5,
                    Name = "Kurva collection resort",
                    Address = "Warshaw",
                    CountryId = 3,
                    Rating = 4.85
                },
                new Hotel
                {
                    Id = 6,
                    Name = "LA sand beach",
                    Address = "Los-Angeles",
                    CountryId = 4,
                    Rating = 4.55
                },
                new Hotel
                {
                    Id = 7,
                    Name = "Sunset sight",
                    Address = "Seattle",
                    CountryId = 4,
                    Rating = 4.85
                }
            );
        }
    }
}
