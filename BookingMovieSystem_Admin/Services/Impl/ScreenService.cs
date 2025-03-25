using BookingMovieSystem_Admin.Dtos;
using BookingMovieSystem_Admin.Models;
using BookingMovieSystem_Admin.Repository;

namespace BookingMovieSystem_Admin.Services.Impl
{
    public class ScreenService : IScreenService
    {
        private readonly IScreenRepository _screenRepository;
        private readonly ICinemaRepository _cinemaRepository;  // Thêm một repository để lấy Cinemas

        public ScreenService(IScreenRepository screenRepository, ICinemaRepository cinemaRepository)
        {
            _screenRepository = screenRepository;
            _cinemaRepository = cinemaRepository;  // Khởi tạo CinemaRepository
        }

        public async Task<IEnumerable<Screen>> GetAllScreensAsync()
        {
            return await _screenRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Screen>> GetScreensWithSeatsAsync()
        {
            return await _screenRepository.GetScreensWithSeatsAsync();
        }

        public async Task<IEnumerable<ScreenDtos>> GetScreensWithSeatCountAsync(string searchItem = "", int? selectedCinemaId = null)
        {
            var screens = await _screenRepository.GetScreensWithSeatsAsync();

            // Lọc theo CinemaId nếu có chọn
            if (selectedCinemaId.HasValue)
            {
                screens = screens.Where(s => s.Cinema.CinemaId == selectedCinemaId.Value);
            }

            // Lọc theo tên màn hình nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchItem))
            {
                screens = screens.Where(s => s.ScreenName.Contains(searchItem, StringComparison.OrdinalIgnoreCase));
            }

            return screens.Select(s => new ScreenDtos
            {
                ScreenId = s.ScreenId,
                CinemaName = s.Cinema.CinemaName,
                ScreenName = s.ScreenName,
                SeatCount = s.ScreenSeats.Count
            }).ToList();
        }

        // Lấy tất cả Cinemas từ cơ sở dữ liệu
        public async Task<IEnumerable<Cinema>> GetCinemasAsync()
        {
            return await _cinemaRepository.GetAllAsync();
        }

        public async Task<Screen> GetScreenByIdAsync(int id)
        {
            return await _screenRepository.GetScreenByIdAsync(id);
        }

        public async Task UpdateScreen(Screen screen)
        {
            await _screenRepository.UpdateScreen(screen);
        }

        // Phương thức AddScreen
        public async Task AddScreen(int screenId, int cinemaId)
        {
            // Lấy thông tin Cinema từ database
            var cinema = await _cinemaRepository.GetByIdAsync(cinemaId);
            if (cinema == null)
            {
                throw new Exception("Cinema not found.");
            }

            // Kiểm tra xem màn hình đã tồn tại chưa
            var screen = await _screenRepository.GetScreenByIdAsync(screenId);
            if (screen != null)
            {
                throw new Exception("Screen already exists.");
            }

            // Tạo màn hình mới
            var newScreen = new Screen
            {
                ScreenId = screenId,
                CinemaId = cinemaId,
                Cinema = cinema // Gán cinema cho màn hình
            };

            // Lưu màn hình mới vào cơ sở dữ liệu
            await _screenRepository.AddScreen(newScreen);
        }
    }
}
