using HotelListing.API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext:IdentityDbContext<ApiUser>
    {
        public HotelListingDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed Data by best practice
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            //Seed Data by another way
            /*
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id= 1,
                    Name="Palestine",
                    ShortName="PS"
                },
                new Country
                {
                    Id = 2,
                    Name = "Algeria",
                    ShortName = "DZ"
                },
                new Country
                {
                    Id = 3,
                    Name = "Turkey",
                    ShortName = "TR"
                }
            );
            */
        }
    }
}
