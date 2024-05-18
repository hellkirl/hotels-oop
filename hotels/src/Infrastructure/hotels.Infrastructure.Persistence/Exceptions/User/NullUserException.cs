namespace hotels.Application.Exceptions.User;

public class NullUserException : Exception
{
    public NullUserException()
    {}

    public NullUserException(string message) : base(message)
    {}
}