using BookingMovieSystem_Admin.Models;
using Microsoft.AspNetCore.SignalR;

namespace BookingMovieSystem_Admin.Hub
{
    public class ShowTimeHub : DynamicHub
    {
        public async Task SendAddNotification(Showtime showtime)
        {
            await Clients.All.SendAsync("ReceiveAddNotification", showtime);
        }

        public async Task SendUpdateNotification(Showtime showtime)
        {
            await Clients.All.SendAsync("ReceiveUpdateNotification", showtime);
        }

        public async Task SendDeleteNotification(int showtimeId)
        {
            await Clients.All.SendAsync("ReceiveDeleteNotification", showtimeId);
        }
    }
}
