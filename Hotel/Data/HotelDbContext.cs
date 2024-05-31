using Microsoft.EntityFrameworkCore;
using HotelAPI.Models;

namespace HotelAPI.Data
{
    public class HotelDbContext : DbContext
    {
        public DbSet<HotelData> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
            .HasOne(b => b.Hotel)
            .WithMany(h => h.Bookings)
            .HasForeignKey(b => b.HotelId);

            modelBuilder.Entity<HotelData>().HasData(
                new HotelData { Id = 1, Name = "Hotel Sunshine", Location = "123 Beach St, Beach City, USA", ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/331846561.jpg?k=5b80ade4354b62ee9359ea993c43ef7524fcad388706bcdb356baf53976a2b1c&o=&hp=1" },
                new HotelData { Id = 2, Name = "Mountain Retreat", Location = "456 Mountain Rd, Mountain Town, Canada", ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/lpibo-ew-1656015868.jpg" },
                new HotelData { Id = 3, Name = "Urban Oasis", Location = "789 City Blvd, Metropolis, USA", ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRp4w1R6jMNjmCqVGt0dbNbNdHLNqIpFyvuPQ&s" },
                new HotelData { Id = 4, Name = "Desert Mirage", Location = "321 Desert St, Desert City, UAE", ImageUrl = "https://media.cnn.com/api/v1/images/stellar/prod/160726150143-us-beautiful-hotels-17-bellagio-2.jpg?q=w_1900,h_1096,x_0,y_0,c_fill" },
                new HotelData { Id = 5, Name = "Forest Haven", Location = "654 Forest Rd, Woodland, Germany", ImageUrl = "https://i.pinimg.com/originals/a5/e6/d4/a5e6d41add196d71126a81dceaad1350.jpg" },
                new HotelData { Id = 6, Name = "Lakeside Resort", Location = "987 Lake St, Lakeside, Switzerland", ImageUrl = "https://media.cntraveler.com/photos/53da828b6dec627b149eeee6/16:9/w_2580,c_limit/fairmont-kea-lani-hawaii-maui.jpg" },
                new HotelData { Id = 7, Name = "Island Paradise", Location = "555 Island Rd, Paradise Island, Maldives", ImageUrl = "https://images.viewretreats.com/wp-content/uploads/2022/10/13213248/Best-Dubai-OneOnly-The-Palm.jpeg" },
                new HotelData { Id = 8, Name = "City Comfort", Location = "101 Central Ave, Big City, USA", ImageUrl = "https://cdn.kiwicollection.com/media/property/PR109109/xl/109109-10-1%20Hotel%20Central%20Park%20-%20Exterior-1%20Hotel%20Central%20Park-2019.jpg?cb=1548199908" },
                new HotelData { Id = 9, Name = "Mountain Lodge", Location = "202 Alpine Rd, Mountain Village, Canada", ImageUrl = "https://www.tourmyindia.com/blog//wp-content/uploads/2022/10/Best-Five-Star-Luxury-Hotels-in-Delhi.jpg" },
                new HotelData { Id = 10, Name = "Seaside Inn", Location = "303 Coastal Dr, Beach Town, USA", ImageUrl = "https://www.visitstaugustine.com/sites/default/files/styles/hero_desktop/public/articles/cover/luxury_st_augustine.jpg?itok=nUHiNwsy" },
                new HotelData { Id = 11, Name = "Country Escape", Location = "404 Countryside Ln, Rural Area, USA", ImageUrl = "https://www.hotelsinheaven.com/wp-content/uploads/2020/10/oneonly-the-palm-dubai-hotel-pool-1500x842.jpg" },
                new HotelData { Id = 12, Name = "City Center Hotel", Location = "505 Downtown St, Urban Area, USA", ImageUrl = "https://abcmallorcastorage.blob.core.windows.net/images/2021/02/nixe-palace-hotel-mallorca.jpg" },
                new HotelData { Id = 13, Name = "Historic Haven", Location = "606 Old Town Rd, Historic City, Germany", ImageUrl = "https://static01.nyt.com/images/2022/06/25/travel/25Budget-SE-Asia/merlin_143824509_9682c473-4c88-468c-992c-325286a441ab-articleLarge.jpg?quality=75&auto=webp&disable=upscale" },
                new HotelData { Id = 14, Name = "Lakeside Inn", Location = "707 Lakeshore Dr, Lakeview, Canada", ImageUrl = "https://www.livelikeitstheweekend.com/wp-content/uploads/2023/04/feature-image-2-1080x720.jpg" },
                new HotelData { Id = 15, Name = "Tropical Retreat", Location = "808 Palm Blvd, Tropical Island, Bahamas", ImageUrl = "https://media.cnn.com/api/v1/images/stellar/prod/160726132219-us-beautiful-hotels-4-four-seasons-maui1.jpg?q=w_1110,c_fill" },
                new HotelData { Id = 16, Name = "Desert Oasis", Location = "909 Sand Dune Rd, Desert Town, UAE", ImageUrl = "https://media.architecturaldigest.com/photos/60c0bbdc20b2a05c5e095928/16:9/w_1280,c_limit/rosewood%20mexico.jpeg" },
                new HotelData { Id = 17, Name = "Forest Retreat", Location = "1010 Pine St, Woodland, Canada", ImageUrl = "https://cdn.i-scmp.com/sites/default/files/d8/images/canvas/2022/10/14/5a579759-1314-4c11-ac78-3398ec9f0c62_8f53a9eb.jpg" },
                new HotelData { Id = 18, Name = "Island Getaway", Location = "1111 Ocean Rd, Paradise Island, Bahamas", ImageUrl = "https://offloadmedia.feverup.com/secretdubai.co/wp-content/uploads/2023/09/26184122/012A7707-1024x683.jpg" },
                new HotelData { Id = 19, Name = "Urban Stay", Location = "1212 Metro St, Big City, USA", ImageUrl = "https://static.theceomagazine.net/wp-content/uploads/2023/04/26003004/Atlantis-the-royal-e1682434586859.jpg" },
                new HotelData { Id = 20, Name = "Beachfront Bliss", Location = "1313 Shoreline Ave, Beach City, USA", ImageUrl = "https://media.cntraveller.com/photos/63f8b4dc46ee886abefcbd4d/16:9/w_2560%2Cc_limit/19%2520-%2520The%2520Palace%2520by%2520night.jpg" },
                new HotelData { Id = 21, Name = "Mountain Escape", Location = "1414 Summit Rd, Mountain Town, Canada", ImageUrl = "https://assets.bwbx.io/images/users/iqjWHBFdfxIU/igl.VyCLsNZQ/v1/-1x-1.jpg" },
                new HotelData { Id = 22, Name = "Historic Hotel", Location = "1515 Old Town Rd, Historic City, Germany", ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/the-maybourne-beverly-hills-exterior-1-1658952097.jpg" }
            );
        }
    }
}
