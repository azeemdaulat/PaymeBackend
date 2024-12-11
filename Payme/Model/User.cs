namespace Payme.Model;

public class User
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public long UserId { get; set; } // Primary Key
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } // Enum: Business, Buyer, Rider
    public string? PhoneNumber { get; set; }
    public DateTime CreatedAt { get; set; }
}
