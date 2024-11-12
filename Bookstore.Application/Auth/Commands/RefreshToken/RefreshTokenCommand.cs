using Bookstore.Application.Auth.Common;
using MediatR;

namespace Bookstore.Application.Auth.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<AuthResponse>
{
    public required string RefreshToken { get; set; }
}
