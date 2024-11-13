using Bookstore.Application.Auth.Common;
using Bookstore.Application.Interfaces;
using MediatR;

namespace Bookstore.Application.Auth.Commands.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand>
{
    private readonly IAuthenticationService _authenticationService;

    public LogoutCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await _authenticationService.Logout(request, cancellationToken);
        return Unit.Value;
    }
}
