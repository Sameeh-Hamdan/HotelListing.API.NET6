using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext:DbContext
    {
        public HotelListingDbContext(DbContextOptions options):base(options)
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
                    Id= 1,
                    Name="Palestine",
                    ShortName="PS"
                }, new Country
                {
                    Id = 2,
                    Name = "Algeria",
                    ShortName = "DZ"
                }, new Country
                {
                    Id = 3,
                    Name = "Turkey",
                    ShortName = "TR"
                }
            );
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name= "Palestine Plaza Hotel",
                    Address= "W684+RQ9, Al Ersal Street, Ramallah",
                    CountryId= 1,
                    Rating= 3.9,
                },
                new Hotel
                {
                    Id = 2,
                    Name = "The Green Park Gaziantep",
                    Address = "Alibey Sokak Mithatpaşa No:1, 27500 Gaziantep, Turkey",
                    CountryId = 3,
                    Rating = 5,
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Four Points by Sheraton Oran",
                    Address = "Boulevard du 19 Mars, Route des falaises ·, 31000 Oran, Algeria",
                    CountryId = 2,
                    Rating = 4.8,
                }
            );
        }
    }
}
