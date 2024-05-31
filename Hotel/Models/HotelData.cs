

namespace HotelAPI.Models
{
    public class HotelData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
