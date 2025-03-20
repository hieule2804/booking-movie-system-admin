using BookingMovieSystem_Admin.Models;
using Microsoft.AspNetCore.SignalR;

namespace BookingMovieSystem_Admin.Hub
{
    public class MovieHub : DynamicHub
    {
        public async Task SendAddNotification(Movie movie)
        {
            await Clients.All.SendAsync("ReceiveAddNotification", movie);
        }
        public async Task SendUpdateNotification(Movie movie)
        {
            await Clients.All.SendAsync("ReceiveUpdateNotification", movie);
        }
        public async Task SendDeleteNotification(int movieId)
        {
            await Clients.All.SendAsync("ReceiveDeleteNotification", movieId);
        }
    }
}
