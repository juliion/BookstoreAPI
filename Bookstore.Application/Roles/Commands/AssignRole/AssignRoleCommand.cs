using MediatR;

namespace Bookstore.Application.Roles.Commands.AssignRole;

public class AssignRoleCommand : IRequest
{
    public Guid UserId { get; set; }
    public required string RoleName { get; set; }
}
