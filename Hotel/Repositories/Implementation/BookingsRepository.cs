using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelAPI.Repositories.Implementation
{
    public class BookingsRepository : IBookingsRepository
    {
        private readonly HotelDbContext _context;

        public BookingsRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> BookHotelRoomAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.Hotel)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.Hotel)
                .ToListAsync();
        }
    }
}
