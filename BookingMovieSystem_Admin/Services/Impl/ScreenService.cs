using BookingMovieSystem_Admin.Dtos;
using BookingMovieSystem_Admin.Models;
using BookingMovieSystem_Admin.Repository;

namespace BookingMovieSystem_Admin.Services.Impl
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepository _screenRepository;

        public ScreenService(IScreenRepository screenRepository)
        {
            _screenRepository = screenRepository;
        }

        public async Task<IEnumerable<Screen>> GetAllScreensAsync()
        {
            return await _screenRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Screen>> GetScreensWithSeatsAsync()
        {
            return await _screenRepository.GetScreensWithSeatsAsync();
        }

        public async Task<IEnumerable<ScreenDtos>> GetScreensWithSeatCountAsync()
        {
            var screens = await _screenRepository.GetScreensWithSeatsAsync();

            return screens.Select(s => new ScreenDtos
            {
                ScreenId = s.ScreenId,
                CinemaId = s.CinemaId,
                ScreenName = s.ScreenName,
                SeatCount = s.ScreenSeats.Count
            }).ToList();
        }

        public async Task<Screen> GetScreenByIdAsync(int id)
        {
            return await _screenRepository.GetScreenByIdAsync(id);
        }
        public async Task UpdateScreen(Screen screen)
        {
            await _screenRepository.UpdateScreen(screen);
        }
    }
}
