namespace HotelAPI.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public HotelData? Hotel { get; set; }
        public string RoomType { get; set; }
        public bool BreakfastIncluded { get; set; }
        public int NumberOfNights { get; set; }
        public int NumberOfGuests { get; set; }
        public decimal TotalCost { get; set; }
    }
}
