using System;
using System.Collections.Generic;

namespace BookingMovieSystem_Admin.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime OrderTimestamp { get; set; }

    public string OrderStatus { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<TransactionLog> TransactionLogs { get; set; } = new List<TransactionLog>();

    public virtual User User { get; set; } = null!;
}
