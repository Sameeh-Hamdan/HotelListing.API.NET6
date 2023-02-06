using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Palestine Plaza Hotel",
                    Address = "W684+RQ9, Al Ersal Street, Ramallah",
                    CountryId = 1,
                    Rating = 3.9,
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
