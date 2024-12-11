namespace Payme.Model;

public class Delivery
{
    public int DeliveryId { get; set; } // Primary Key
    public int OrderId { get; set; } // Foreign Key
    public long RiderId { get; set; } // Foreign Key (UserId of the Rider)
    public string Status { get; set; } // Enum: Pending, Accepted, Rejected, Delivered
    public DateTime AssignedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }

    // Navigation properties
    public Order Order { get; set; }
    public User Rider { get; set; }
}
