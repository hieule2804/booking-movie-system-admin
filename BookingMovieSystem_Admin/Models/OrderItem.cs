using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ScreenSeatId { get; set; }

    public decimal PriceCharged { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ScreenSeat ScreenSeat { get; set; } = null!;

    public virtual Ticket? Ticket { get; set; }
}
