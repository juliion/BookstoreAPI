using Bookstore.Application.Interfaces;
using MediatR;

namespace Bookstore.Application.Roles.Commands.AssignRole;

public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommand>
{
    private readonly IRoleService _roleService;

    public AssignRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<Unit> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleService.AssignRoleToUser(request.UserId, request.RoleName);
        return Unit.Value;
    }
}
