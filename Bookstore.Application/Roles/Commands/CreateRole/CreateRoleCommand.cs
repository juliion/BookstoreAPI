using MediatR;

namespace Bookstore.Application.Roles.Commands.CreateRole;

public class CreateRoleCommand : IRequest
{
    public required string RoleName { get; set; }
}
