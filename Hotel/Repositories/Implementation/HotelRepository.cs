using HotelAPI.Data;
using HotelAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Repositories.Interface;

namespace HotelAPI.Repositories.Implementation
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HotelData>> GetAllHotelsAsync()
        {
            return await _context.Hotels.ToListAsync();
        }

        public async Task<IEnumerable<HotelData>> GetHotelsByCityAsync(string city)
        {
            var hotels = await _context.Hotels.ToListAsync();

            return hotels.Where(h => h.Location.Split(',')[1].Trim().ToLower().Contains(city.ToLower()));
        }
        public async Task<HotelData> GetHotelByIdAsync(int id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<IEnumerable<HotelData>> GetHotelsByCountryAsync(string country)
        {
            var hotels = await _context.Hotels.ToListAsync();

            return hotels.Where(h => h.Location.Split(',')[2].Trim().ToLower() == (country.ToLower()));
        }
    }
}
