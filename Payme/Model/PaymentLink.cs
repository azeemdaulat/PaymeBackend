namespace Payme.Model;

public class PaymentLink
{
    public int Id { get; set; } // Primary Key
    public string OrderId { get; set; }
    public string BuyerName { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
