namespace Payme.Model;

public class Payment
{
    public int PaymentId { get; set; } // Primary Key
    public int OrderId { get; set; } // Foreign Key
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } // Enum: CreditCard, PayPal, etc.
    public string TransactionId { get; set; } // External transaction ID
    public string Status { get; set; } // Enum: Pending, Completed, Failed
    public DateTime CreatedAt { get; set; }

    // Navigation property
    public Order Order { get; set; }
}
