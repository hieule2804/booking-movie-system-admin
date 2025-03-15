using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class ScreenSeat
{
    public int ScreenSeatId { get; set; }

    public int ScreenId { get; set; }

    public string SeatLabel { get; set; } = null!;

    public int SeatTypeId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Screen Screen { get; set; } = null!;

    public virtual ICollection<SeatLock> SeatLocks { get; set; } = new List<SeatLock>();

    public virtual SeatType SeatType { get; set; } = null!;
}
