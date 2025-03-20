using BookingMovieSystem_Admin.Models;
using Microsoft.AspNetCore.SignalR;

namespace BookingMovieSystem_Admin.Hub
{
    public class ScreenSeatHub : DynamicHub
    {
        public async Task SendAddNotification(ScreenSeat screenSeat)
        {
            await Clients.All.SendAsync("ReceiveAddNotification", screenSeat);
        }

        public async Task SendUpdateNotification(ScreenSeat screenSeat)
        {
            await Clients.All.SendAsync("ReceiveUpdateNotification", screenSeat);
        }

        public async Task SendDeleteNotification(int screenseatId)
        {
            await Clients.All.SendAsync("ReceiveDeleteNotification", screenseatId);
        }
    }
}
