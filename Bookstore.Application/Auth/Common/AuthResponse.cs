namespace Bookstore.Application.Auth.Common;

public class AuthResponse
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}
