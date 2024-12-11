using Payme.Model;

namespace Payme.Service;

public class UserService
{
    private readonly List<User> _users = new List<User>();

    // Register user
    public User Register(string userName, string password)
    {
        if (_users.Any(u => u.UserName == userName))
        {
            throw new InvalidOperationException("Username already exists.");
        }

        var newUser = new User
        {
            UserName = userName,
            Password = password // In a real app, hash and salt the password here
        };

        _users.Add(newUser);
        return newUser;
    }

    // Validate user for login
    public User ValidateUser(string userName, string password)
    {
        return _users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
    }
}
