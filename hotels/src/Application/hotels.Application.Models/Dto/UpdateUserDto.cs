namespace hotels.Application.Models.Dto;

public class UpdateUserDto
{
    public uint UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; } // First name of the user
    public string LastName { get; set; } // Last name of the user
    public string Email { get; set; } // Email of the user
    public string Phone { get; set; } // Phone of the user
    public string Passport { get; set; } // Passport of the user
    public DateTime Birthday { get; set; } // Birthday of the user
}