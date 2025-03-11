using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookingMovieSystem_Admin.Models;

public partial class Showtime
{
    public int ShowtimeId { get; set; }

    public int MovieId { get; set; }

    public int ScreenId { get; set; }

    public int? ScreenSeatId { get; set; }

    public DateOnly ShowDate { get; set; }

    public TimeOnly ShowTime { get; set; }

    public string ExperienceType { get; set; } = null!;
    [JsonIgnore]
    public virtual Movie Movie { get; set; } = null!;

    public virtual Screen Screen { get; set; } = null!;
}
