using AutoMapper;
using Bookstore.Application.Auth.Commands.Login;
using Bookstore.Application.Auth.Commands.Logout;
using Bookstore.Application.Auth.Commands.RefreshToken;
using Bookstore.Application.Auth.Commands.Register;
using BookstoreAPI.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookstoreAPI.Controllers;

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
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        var command = new RefreshTokenCommand{ RefreshToken = refreshToken };
        var authResponse = await Mediator.Send(command);
        return Ok(authResponse);
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout(string refreshToken)
    {
        var command = new LogoutCommand { RefreshToken = refreshToken };
        var authResponse = await Mediator.Send(command);
        return Ok(authResponse);
    }
}
