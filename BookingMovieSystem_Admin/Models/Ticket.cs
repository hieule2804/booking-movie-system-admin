using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int OrderItemId { get; set; }

    public string UniqueCode { get; set; } = null!;

    public DateTime IssueTimestamp { get; set; }

    public string TicketStatus { get; set; } = null!;

    public DateTime? ScannedTimestamp { get; set; }

    public virtual OrderItem OrderItem { get; set; } = null!;

    public virtual ICollection<TicketScanLog> TicketScanLogs { get; set; } = new List<TicketScanLog>();
}
