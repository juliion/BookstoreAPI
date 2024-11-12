using Bookstore.Application.Auth.Common;
using Bookstore.Application.Interfaces;
using MediatR;

namespace Bookstore.Application.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponse>
{
    private readonly IAuthenticationService _authenticationService;

    public RegisterCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<AuthResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await _authenticationService.Register(request, cancellationToken);
    }
}
