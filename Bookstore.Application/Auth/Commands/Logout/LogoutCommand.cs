using MediatR;

namespace Bookstore.Application.Auth.Commands.Logout;

public class LogoutCommand : IRequest
{
    public required string RefreshToken { get; set; }
}
