using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookstoreAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BaseController : ControllerBase
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    internal Guid UserId
    {
        get
        {
            if (!User.Identity.IsAuthenticated)
                return Guid.Empty;

            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(claimValue, out var userId) ? userId : Guid.Empty;
        }
    }
}
