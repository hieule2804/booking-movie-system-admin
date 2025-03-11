using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class SeatType
{
    public int SeatTypeId { get; set; }

    public string SeatTypeName { get; set; } = null!;

    public decimal BasePrice { get; set; }

    public virtual ICollection<ScreenSeat> ScreenSeats { get; set; } = new List<ScreenSeat>();
}
