using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<SeatLock> SeatLocks { get; set; } = new List<SeatLock>();

    public virtual ICollection<TicketScanLog> TicketScanLogs { get; set; } = new List<TicketScanLog>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
