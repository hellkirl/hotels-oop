namespace hotels.Application.Exceptions.User;

public class WrongPassword : Exception
{
    public WrongPassword() { }

    public WrongPassword(string message)
        : base(message) { }

    public WrongPassword(string message, Exception innerException)
        : base(message, innerException) { }
}