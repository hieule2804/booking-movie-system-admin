using BookingMovieSystem_Admin.Components.Pages.Shares;
using BookingMovieSystem_Admin.Dtos;
using BookingMovieSystem_Admin.Models;
using System.Threading.Tasks;

namespace BookingMovieSystem_Admin.Services
{
    public interface IScreenSeatService
    {
        Task<IEnumerable<ScreenSeat>> GetScreensByScreenId(int screenId);
        Task AddScreenSeat(ScreenSeat screenSeat);
        Task<bool> DeleteScreenSeat(int screenSeatId);
    }
}
