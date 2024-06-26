namespace Hotels.Infrastructure.Persistence.Exceptions;

public class NotFound : Exception
{
    public NotFound() { }

    public NotFound(string message)
        : base(message) { }

    public NotFound(string message, Exception innerException)
        : base(message, innerException) { }
}