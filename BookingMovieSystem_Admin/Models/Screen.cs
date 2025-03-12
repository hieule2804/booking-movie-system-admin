using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Thêm namespace này để sử dụng các annotation

namespace BookingMovieSystem_Admin.Models;

public partial class Screen
{
    public int ScreenId { get; set; }

    [Required(ErrorMessage = "CinemaId is required")]
    public int CinemaId { get; set; }

    [Required(ErrorMessage = "Screen Name is required")]
    [StringLength(100, ErrorMessage = "Screen Name can't be longer than 100 characters")]
    public string ScreenName { get; set; } = null!;

    public virtual Cinema Cinema { get; set; } = null!;

    public virtual ICollection<ScreenSeat> ScreenSeats { get; set; } = new List<ScreenSeat>();

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
