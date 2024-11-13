using Bookstore.Application.Auth.Common;
using Bookstore.Application.Interfaces;
using MediatR;

namespace Bookstore.Application.Auth.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AuthResponse>
{
    private readonly IAuthenticationService _authenticationService;

    public RefreshTokenCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<AuthResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {

        return await _authenticationService.RefreshToken(request, cancellationToken);
    }
}
