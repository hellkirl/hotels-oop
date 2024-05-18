namespace hotels.Application.Models.UserModels;

/// <summary>
/// This is the class that represents the User entity
/// </summary>
public class UserModel
{
    public uint UserId { get; set; } // Primary key
    public string Login { get; set; } // User login
    public string PasswordHash { get; set; }// User password
}

