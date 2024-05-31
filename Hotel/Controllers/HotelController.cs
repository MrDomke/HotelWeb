using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Repositories.Implementation;
using HotelAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelData>> GetHotelById(int id)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            return hotel;
        }

        [HttpGet]
        public async Task<IEnumerable<HotelData>> GetHotels()
        {
            return await _hotelRepository.GetAllHotelsAsync();
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<HotelData>>> SearchHotelsByCity([FromQuery] string city)
        {
            var hotels = await _hotelRepository.GetHotelsByCityAsync(city);
            return Ok(hotels);
        }
        [HttpGet("searchbycountry/{country}")]
        public async Task<ActionResult<IEnumerable<HotelData>>> SearchHotelsByCountry(string country)
        {
            var hotels = await _hotelRepository.GetHotelsByCountryAsync(country);
            return Ok(hotels);
        }
    }
}
