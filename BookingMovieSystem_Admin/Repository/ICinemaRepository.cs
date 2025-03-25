using BookingMovieSystem_Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingMovieSystem_Admin.Repository
{
    public interface ICinemaRepository
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int cinemaId);
    }
}
