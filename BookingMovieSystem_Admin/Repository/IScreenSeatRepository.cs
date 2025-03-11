using BookingMovieSystem_Admin.Components.Pages.Shares;
using BookingMovieSystem_Admin.Dtos;
using BookingMovieSystem_Admin.Models;

namespace BookingMovieSystem_Admin.Repository
{
    public interface IScreenSeatRepository
    {
        Task<IEnumerable<ScreenSeat>> GetScreensByScreenId(int screenId);
    }
}
