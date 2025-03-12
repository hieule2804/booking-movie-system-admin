using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Thêm namespace này để sử dụng các annotation
using System.Text.Json.Serialization;

namespace BookingMovieSystem_Admin.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Genre is required")]
    [StringLength(50, ErrorMessage = "Genre can't be longer than 50 characters")]
    public string Genre { get; set; } = null!;

    [Required(ErrorMessage = "Duration is required")]
    [Range(1, 300, ErrorMessage = "Duration must be between 1 and 300 minutes")]
    public int Duration { get; set; }

    [Required(ErrorMessage = "Language is required")]
    [StringLength(50, ErrorMessage = "Language can't be longer than 50 characters")]
    public string Language { get; set; } = null!;

    [Required(ErrorMessage = "Rating is required")]
    [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10")]
    public float Rating { get; set; }

    [Required(ErrorMessage = "Release Date is required")]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [StringLength(1000, ErrorMessage = "Description can't be longer than 1000 characters")]
    public string Description { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
