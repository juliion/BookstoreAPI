using Bookstore.Application.Interfaces;
using MediatR;

namespace Bookstore.Application.Roles.Commands.RemoveRoleFromUser;

public class RemoveRoleFromUserCommandHandler : IRequestHandler<RemoveRoleFromUserCommand>
{
    private readonly IRoleService _roleService;

    public RemoveRoleFromUserCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<Unit> Handle(RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
    {
        await _roleService.RemoveRoleFromUser(request.UserId, request.RoleName);
        return Unit.Value;
    }
}