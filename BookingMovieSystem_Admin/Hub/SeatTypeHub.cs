using BookingMovieSystem_Admin.Models;
using Microsoft.AspNetCore.SignalR;

namespace BookingMovieSystem_Admin.Hub
{
    public class SeatTypeHub : DynamicHub
    {
            public async Task SendAddNotification(SeatType seatType)
            {
                await Clients.All.SendAsync("ReceiveAddNotification", seatType);
            }

            public async Task SendUpdateNotification(SeatType seatType)
            {
                await Clients.All.SendAsync("ReceiveUpdateNotification", seatType);
            }

            public async Task SendDeleteNotification(int seatTypeId)
            {
                await Clients.All.SendAsync("ReceiveDeleteNotification", seatTypeId);
            }
    }
}
