using BookingMovieSystem_Admin.Models;
using Microsoft.AspNetCore.SignalR;

namespace BookingMovieSystem_Admin.Hub
{
    public class CinemaHub : DynamicHub
    {
        public async Task SendAddNotification(Cinema cinema)
        {
            await Clients.All.SendAsync("ReceiveAddNotification", cinema);
        }
        public async Task SendUpdateNotification(Cinema cinema)
        {
            await Clients.All.SendAsync("ReceiveUpdateNotification", cinema);
        }
        public async Task SendDeleteNotification(int cinemaId)
        {
            await Clients.All.SendAsync("ReceiveDeleteNotification", cinemaId);
        }
    }
}
