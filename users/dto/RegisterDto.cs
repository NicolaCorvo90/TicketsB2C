using System.ComponentModel.DataAnnotations;

namespace TicketsB2C.users;

public class RegisterDto
{
    [Required(ErrorMessage = "Email is required.")]
    public required string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    public required string Password { get; set; }
}