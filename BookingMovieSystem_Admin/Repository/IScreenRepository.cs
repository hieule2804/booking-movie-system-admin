using BookingMovieSystem_Admin.Models;

namespace BookingMovieSystem_Admin.Repository
{
    public interface IScreenRepository
    {
        Task<IEnumerable<Screen>> GetScreensWithSeatsAsync();

        Task<IEnumerable<Screen>> GetAllAsync();

        Task<Screen> GetScreenByIdAsync(int id);

    }
}
