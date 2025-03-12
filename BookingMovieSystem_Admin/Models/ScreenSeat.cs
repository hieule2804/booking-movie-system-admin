using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Thêm namespace này để sử dụng các annotation

namespace BookingMovieSystem_Admin.Models;

public partial class ScreenSeat
{
    public int ScreenSeatId { get; set; }

    [Required(ErrorMessage = "ScreenId is required")]
    public int ScreenId { get; set; }

    [Required(ErrorMessage = "Seat Label is required")]
    [StringLength(10, ErrorMessage = "Seat Label can't be longer than 10 characters")]
    public string SeatLabel { get; set; } = null!;

    [Required(ErrorMessage = "SeatTypeId is required")]
    public int SeatTypeId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Screen Screen { get; set; } = null!;

    public virtual ICollection<SeatLock> SeatLocks { get; set; } = new List<SeatLock>();

    public virtual SeatType SeatType { get; set; } = null!;
}
