using AutoMapper;
using Bookstore.Application.Auth.Commands.Login;
using Bookstore.Application.Auth.Commands.Logout;
using Bookstore.Application.Auth.Commands.RefreshToken;
using Bookstore.Application.Auth.Commands.Register;
using BookstoreAPI.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers;


[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IMapper _mapper;

    public AuthController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequestModel loginRequest)
    {
        var command = _mapper.Map<LoginCommand>(loginRequest);
        var authResponse = await Mediator.Send(command);
        return Ok(authResponse);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequestModel registerRequest)
    {
        var command = _mapper.Map<RegisterCommand>(registerRequest);

        var authResponse = await Mediator.Send(command);
        return Ok(authResponse);
    }

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken(TokenRequestModel tokenRequest)
    {
        var command = _mapper.Map<RefreshTokenCommand>(tokenRequest);
        var authResponse = await Mediator.Send(command);
        return Ok(authResponse);
    }

    [Authorize]
    [HttpPost("Logout")]
    public async Task<IActionResult> Logout(TokenRequestModel tokenRequest)
    {
        var command = _mapper.Map<LogoutCommand>(tokenRequest);
        command.UserId = UserId;
        var authResponse = await Mediator.Send(command);
        return Ok(authResponse);
    }
}
