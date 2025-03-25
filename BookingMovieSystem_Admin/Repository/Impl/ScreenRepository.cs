using BookingMovieSystem_Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingMovieSystem_Admin.Repository.Impl
{
    public class ScreenRepository : IScreenRepository
    {
        private readonly G5MovieTicketBookingSystemContext _context;

        public ScreenRepository(G5MovieTicketBookingSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Screen>> GetAllAsync()
        {
            return await _context.Screens.ToListAsync();
        }

        public async Task<Screen> GetScreenByIdAsync(int id)
        {
            return await _context.Screens.FindAsync(id);
        }

        public async Task<IEnumerable<Screen>> GetScreensWithSeatsAsync()
        {
            return await _context.Screens
                .Include(s => s.ScreenSeats)
                .ThenInclude(ss => ss.SeatType)
                .Include(s => s.Cinema)
                .ToListAsync();
        }
        public async Task UpdateScreen(Screen screen)
        {
            _context.Screens.Update(screen);
            await _context.SaveChangesAsync();
        }
        public async Task AddScreen(Screen screen)
        {
            _context.Screens.Add(screen);
            await _context.SaveChangesAsync();
        }
    }
}
