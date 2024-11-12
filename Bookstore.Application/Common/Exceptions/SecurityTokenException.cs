namespace Bookstore.Application.Common.Exceptions;

public class SecurityTokenException : Exception
{
    public SecurityTokenException(string? message) : base(message)
    {
    }
}
