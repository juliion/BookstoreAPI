using Bookstore.Application.Roles.Commands.AssignRole;
using Bookstore.Application.Roles.Commands.CreateRole;
using Bookstore.Application.Roles.Commands.DeleteRole;
using Bookstore.Application.Roles.Commands.RemoveRoleFromUser;
using Bookstore.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers;

[Route("api/[controller]")]
[Authorize(Roles = Roles.Admin)]
public class RolesController : BaseController
{
    [HttpPost("CreateRole")]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        var command = new CreateRoleCommand { RoleName = roleName };
        await Mediator.Send(command);
        return Ok();
    }

    [HttpDelete("DeleteRole")]
    public async Task<IActionResult> DeleteRole(string roleName)
    {
        var command = new DeleteRoleCommand { RoleName = roleName };
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("AssignRole")]
    public async Task<IActionResult> AssignRole(Guid userId, string roleName)
    {
        var command = new AssignRoleCommand { UserId = userId, RoleName = roleName };
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("RemoveRoleFromUser")]
    public async Task<IActionResult> RemoveRoleFromUser(Guid userId, string roleName)
    {
        var command = new RemoveRoleFromUserCommand { UserId = userId, RoleName = roleName };
        await Mediator.Send(command);
        return Ok();
    }
}
