using MediatR;

namespace Bookstore.Application.Auth.Commands.Logout;

public class LogoutCommand : IRequest
{
    public Guid UserId { get; set; }
    public required string RefreshToken { get; set; }
}
