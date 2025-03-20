using BookingMovieSystem_Admin.Models;
using Microsoft.AspNetCore.SignalR;

namespace BookingMovieSystem_Admin.Hub
{
    public class UserHub : DynamicHub
    {
        public async Task SendAddNotification(User user)
        {
            await Clients.All.SendAsync("ReceiveAddNotification", user);
        }

        public async Task SendUpdateNotification(User user)
        {
            await Clients.All.SendAsync("ReceiveUpdateNotification", user);
        }

        public async Task SendDeleteNotification(int userId)
        {
            await Clients.All.SendAsync("ReceiveDeleteNotification", userId);
        }
    }
}
