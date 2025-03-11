using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int Duration { get; set; }

    public string Language { get; set; } = null!;

    public float Rating { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
