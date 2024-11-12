using Bookstore.Application.Auth.Common;
using Bookstore.Application.Interfaces;
using MediatR;

namespace Bookstore.Application.Auth.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
{
    private readonly IAuthenticationService _authenticationService;

    public LoginCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.Login(request, cancellationToken);
    }
}
