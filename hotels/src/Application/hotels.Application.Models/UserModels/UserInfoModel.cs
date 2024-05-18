namespace hotels.Application.Models.UserModels;

/// <summary>
/// This is the class that represents the User Info entity
/// </summary>
public class UserInfoModel
{
    public uint UserInfoId { get; set; } // Primary key
    public uint UserId { get; set; } // Foreign Key of User
    public string FirstName { get; set; } // First name of the user
    public string LastName { get; set; } // Last name of the user
    public string Phone { get; set; } // Phone of the user
    public string Email { get; set; } // Email of the user
    public string Passport { get; set; } // Passport of the user
    public DateTime Birthday { get; set; } // Birthday of the user
}