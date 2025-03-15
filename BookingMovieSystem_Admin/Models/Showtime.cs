using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class Showtime
{
    public int ShowtimeId { get; set; }

    public int MovieId { get; set; }

    public int ScreenId { get; set; }

    public DateOnly ShowDate { get; set; }

    public TimeOnly ShowTime { get; set; }

    public string ExperienceType { get; set; } = null!;

    public bool IsSoldOut { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Screen Screen { get; set; } = null!;

    public virtual ICollection<SeatLock> SeatLocks { get; set; } = new List<SeatLock>();
}
