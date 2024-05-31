using HotelAPI.Data;
using HotelAPI.Models;
using HotelAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelAPI.Repositories.Interface
{
    public interface IHotelRepository
    {
        Task<IEnumerable<HotelData>> GetAllHotelsAsync();
        Task<IEnumerable<HotelData>> GetHotelsByCityAsync(string city);
        Task<IEnumerable<HotelData>> GetHotelsByCountryAsync(string country);
        Task<HotelData> GetHotelByIdAsync(int id);
    }
}
