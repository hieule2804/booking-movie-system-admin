using BookingMovieSystem_Admin.Dtos;
using BookingMovieSystem_Admin.Models;

namespace BookingMovieSystem_Admin.Services
{
    public interface IScreenService
    {
        Task<IEnumerable<Screen>> GetAllScreensAsync();
        Task<IEnumerable<Screen>> GetScreensWithSeatsAsync();
        Task<IEnumerable<ScreenDtos>> GetScreensWithSeatCountAsync();

        Task<Screen> GetScreenByIdAsync(int id);
        Task UpdateScreen(Screen screen); 

    }
}
