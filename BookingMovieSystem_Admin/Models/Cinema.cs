using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // Thêm namespace này để sử dụng các annotation

namespace BookingMovieSystem_Admin.Models;

public partial class Cinema
{
    public int CinemaId { get; set; }

    [Required(ErrorMessage = "Cinema Name is required")]
    [StringLength(100, ErrorMessage = "Cinema Name can't be longer than 100 characters")]
    public string CinemaName { get; set; } = null!;

    [Required(ErrorMessage = "City is required")]
    [StringLength(50, ErrorMessage = "City can't be longer than 50 characters")]
    public string City { get; set; } = null!;

    [Required(ErrorMessage = "Address is required")]
    [StringLength(200, ErrorMessage = "Address can't be longer than 200 characters")]
    public string Address { get; set; } = null!;

    public virtual ICollection<Screen> Screens { get; set; } = new List<Screen>();
}
