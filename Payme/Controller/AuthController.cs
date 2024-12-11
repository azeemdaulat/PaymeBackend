using Microsoft.AspNetCore.Mvc;
using Payme.DTO;
using Payme.Model;
using Payme.Service;

namespace Payme.Controller;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly JwtService _jwtService;

    public AuthController(UserService userService, JwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }
    // Register user endpoint
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto registerDto)
    {
        if (registerDto == null || string.IsNullOrEmpty(registerDto.UserName) || string.IsNullOrEmpty(registerDto.Password))
        {
            return BadRequest("Username and password are required.");
        }

        try
        {
            var newUser = _userService.Register(registerDto.UserName, registerDto.Password);
            return Ok(new { message = "User registered successfully", user = newUser.UserName });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message }); // Username already exists
        }
    }
    // Mock user store (usually, you would validate against a DB)
    private static readonly List<User> Users = new List<User>
    {
        new User { UserName = "testuser", Password = "password123" }
    };

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        var user = Users.FirstOrDefault(u => u.UserName == loginDto.UserName && u.Password == loginDto.Password);

        if (user == null)
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        var token = _jwtService.GenerateJwtToken(user.UserName);
        return Ok(new { Token = token });
    }
}
