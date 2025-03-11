using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class Screen
{
    public int ScreenId { get; set; }

    public int CinemaId { get; set; }

    public string ScreenName { get; set; } = null!;

    public virtual Cinema Cinema { get; set; } = null!;

    public virtual ICollection<ScreenSeat> ScreenSeats { get; set; } = new List<ScreenSeat>();

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
