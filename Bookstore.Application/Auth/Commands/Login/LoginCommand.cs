using Bookstore.Application.Auth.Common;
using MediatR;

namespace Bookstore.Application.Auth.Commands.Login;

public class LoginCommand : IRequest<AuthResponse>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
