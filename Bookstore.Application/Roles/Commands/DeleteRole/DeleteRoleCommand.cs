using MediatR;

namespace Bookstore.Application.Roles.Commands.DeleteRole;

public class DeleteRoleCommand : IRequest
{
    public required string RoleName { get; set; }
}
