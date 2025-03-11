using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingMovieSystem_Admin.Models;

public partial class TicketScanLog
{
    [Key]
    public int ScanId { get; set; }

    public int TicketId { get; set; }

    public DateTime ScanTimestamp { get; set; }

    public int ScannedBy { get; set; }

    public string ScanResult { get; set; } = null!;

    public virtual User ScannedByNavigation { get; set; } = null!;

    public virtual Ticket Ticket { get; set; } = null!;
}
