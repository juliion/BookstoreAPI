using Bookstore.Application.Auth.Commands.Login;
using Bookstore.Application.Auth.Commands.Register;
using Bookstore.Application.Auth.Common;

namespace Bookstore.Application.Interfaces;

public interface IAuthenticationService
{
    Task<AuthResponse> Register(RegisterCommand request, CancellationToken cancellationToken);
    Task<AuthResponse> Login(LoginCommand request, CancellationToken cancellationToken);
    Task<AuthResponse> RefreshToken(string token, CancellationToken cancellationToken);
    Task RevokeToken(string token, CancellationToken cancellationToken);
}
