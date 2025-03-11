using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class SeatLock
{
    public int SeatLockId { get; set; }

    public int UserId { get; set; }

    public int ScreenSeatId { get; set; }

    public DateTime LockStartTime { get; set; }

    public DateTime LockExpiryTime { get; set; }

    public string LockStatus { get; set; } = null!;

    public virtual ScreenSeat ScreenSeat { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
