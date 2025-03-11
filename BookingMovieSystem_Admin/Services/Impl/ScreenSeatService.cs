using BookingMovieSystem_Admin.Components.Pages.Shares;
using BookingMovieSystem_Admin.Dtos;
using BookingMovieSystem_Admin.Models;
using BookingMovieSystem_Admin.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingMovieSystem_Admin.Services.Impl
{
    public class ScreenSeatService : IScreenSeatService
    {
        private readonly IScreenSeatRepository _screenSeatRepository;

        public ScreenSeatService(IScreenSeatRepository screenSeatRepository)
        {
            _screenSeatRepository = screenSeatRepository;
        }

        public async Task<IEnumerable<ScreenSeat>> GetScreensByScreenId(int screenId)
        {
            return await _screenSeatRepository.GetScreensByScreenId(screenId);
        }

        public async Task AddScreenSeat(ScreenSeat screenSeat)
        {
            await _screenSeatRepository.AddScreenSeat(screenSeat);
        }

        public async Task<bool> DeleteScreenSeat(int screenSeatId)
        {
            return await _screenSeatRepository.DeleteScreenSeat(screenSeatId);
        }
    }
}
