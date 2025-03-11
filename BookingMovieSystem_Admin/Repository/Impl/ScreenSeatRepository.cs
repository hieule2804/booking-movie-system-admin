using BookingMovieSystem_Admin.Components.Pages.Shares;
using BookingMovieSystem_Admin.Dtos;
using BookingMovieSystem_Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingMovieSystem_Admin.Repository.Impl
{
    public class ScreenSeatRepository : IScreenSeatRepository
    {
        private readonly G5MovieTicketBookingSystemContext _context;

        public ScreenSeatRepository(G5MovieTicketBookingSystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ScreenSeat>> GetScreensByScreenId(int screenId)
        {
            return await _context.ScreenSeats
                .Where(ss => ss.ScreenId == screenId)
                .Include(ss => ss.SeatType)
                .ToListAsync();
        }

    }
}
