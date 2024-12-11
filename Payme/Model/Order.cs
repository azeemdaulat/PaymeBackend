namespace Payme.Model;

public class Order
{
    public int OrderId { get; set; } // Primary Key
    public string OrderNumber { get; set; } // Unique identifier for the order
    public long UserId { get; set; } // Foreign Key
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } // Enum: Pending, Paid, Shipped, Delivered
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Navigation property
    public User User { get; set; }
}
