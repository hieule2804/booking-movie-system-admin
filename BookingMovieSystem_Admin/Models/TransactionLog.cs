using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class TransactionLog
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public string PaymentGateway { get; set; } = null!;

    public DateTime TransactionTimestamp { get; set; }

    public decimal Amount { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public string GatewayResponse { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
