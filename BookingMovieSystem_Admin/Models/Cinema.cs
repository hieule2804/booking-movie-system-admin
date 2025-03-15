using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class Cinema
{
    public int CinemaId { get; set; }

    public string CinemaName { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Screen> Screens { get; set; } = new List<Screen>();
}
