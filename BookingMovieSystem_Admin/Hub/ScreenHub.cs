using BookingMovieSystem_Admin.Models;
using Microsoft.AspNetCore.SignalR;

namespace BookingMovieSystem_Admin.Hub
{
    public class ScreenHub : DynamicHub
    {
        public async Task SendAddNotification(Screen screen)
        {
            await Clients.All.SendAsync("ReceiveAddNotification", screen);
        }
        public async Task SendUpdateNotification(Screen screen)
        {
            await Clients.All.SendAsync("ReceiveUpdateNotification", screen);
        }
        public async Task SendDeleteNotification(int screenId)
        {
            await Clients.All.SendAsync("ReceiveDeleteNotification", screenId);
        }
    }
}
