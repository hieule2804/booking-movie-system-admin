using BookingMovieSystem_Admin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingMovieSystem_Admin.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly G5MovieTicketBookingSystemContext _context;

        public CinemaRepository(G5MovieTicketBookingSystemContext context)
        {
            _context = context;
        }

        // Lấy tất cả Cinemas
        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }

        // Lấy Cinema theo CinemaId
        public async Task<Cinema> GetByIdAsync(int cinemaId)
        {
            return await _context.Cinemas
                .FirstOrDefaultAsync(c => c.CinemaId == cinemaId); // Trả về null nếu không tìm thấy
        }
    }
}
