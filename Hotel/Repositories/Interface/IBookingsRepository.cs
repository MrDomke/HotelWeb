using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repositories.Interface
{
    public interface IBookingsRepository
    {
        Task<Booking> BookHotelRoomAsync(Booking booking);
        Task<Booking> GetBookingByIdAsync(int id);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
    }
}
