using MediatR;

namespace hotels.Application.Events.User.Commands;

public class UpdateUserCommand : IRequest
{
    public uint UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime Birthday { get; set; }
    public string Passport { get; set; }
    
    public UpdateUserCommand(uint userId, string login, string password, string firstName, string lastName, string phone, string email, DateTime birthday, string passport)
    {
        UserId = userId;
        Login = login;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
        Birthday = birthday;
        Passport = passport;
    }
}