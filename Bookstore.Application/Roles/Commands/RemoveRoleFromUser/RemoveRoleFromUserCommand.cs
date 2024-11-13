using MediatR;

namespace Bookstore.Application.Roles.Commands.RemoveRoleFromUser;

public class RemoveRoleFromUserCommand : IRequest
{
    public Guid UserId { get; set; }
    public required string RoleName { get; set; }
}
