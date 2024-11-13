using Bookstore.Application.Auth.Commands.Login;
using Bookstore.Application.Auth.Commands.Logout;
using Bookstore.Application.Auth.Commands.RefreshToken;
using Bookstore.Application.Auth.Commands.Register;
using Bookstore.Application.Auth.Common;
using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Constants;
using Bookstore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly TokenService _tokenService;
    private readonly IBookstoreDbContext _context;

    public AuthenticationService(
        UserManager<User> userManager,
        TokenService tokenService,
        IBookstoreDbContext context)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _context = context;
    }

    public async Task<AuthResponse> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.Email,
            Email = request.Email,
            Name = request.Name,
            Surname = request.Surname,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new Exception($"User creation failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        await _userManager.AddToRoleAsync(user, Roles.User);

        return await GenerateAuthenticationResultForUser(user, cancellationToken);
    }

    public async Task<AuthResponse> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new UnauthorizedException();
        }

        return await GenerateAuthenticationResultForUser(user, cancellationToken);
    }

    public async Task<AuthResponse> RefreshToken(RefreshTokenCommand token, CancellationToken cancellationToken)
    {
        var refreshToken = await _context.UserRefreshTokens
            .FirstOrDefaultAsync(refresh => refresh.Token == token.RefreshToken);
        if (refreshToken == null || refreshToken.Expires < DateTime.UtcNow)
            throw new SecurityTokenException("Unknown or invalid refresh token.");


        var newRefreshToken = _tokenService.GenerateRefreshToken();
        newRefreshToken.UserId = refreshToken.UserId;

        _context.UserRefreshTokens.Remove(refreshToken);
        _context.UserRefreshTokens.Add(newRefreshToken);
        await _context.SaveChangesAsync(cancellationToken);

        var user = await _userManager.FindByIdAsync(refreshToken.UserId.ToString());
        var accessToken = await _tokenService.GenerateAccessToken(user);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken.Token,
        };
    }
    public async Task Logout(LogoutCommand token, CancellationToken cancellationToken)
    {
        var refreshToken = await _context.UserRefreshTokens
            .FirstOrDefaultAsync(refresh => refresh.Token == token.RefreshToken);
        
        if (refreshToken == null)
            throw new SecurityTokenException("Invalid refresh token.");
        if(refreshToken.UserId != token.UserId)
        {
            throw new UnauthorizedException();
        }

        _context.UserRefreshTokens.Remove(refreshToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    private async Task<AuthResponse> GenerateAuthenticationResultForUser(User user, CancellationToken cancellationToken)
    {
        var accessToken = await _tokenService.GenerateAccessToken(user);
        var refreshToken = _tokenService.GenerateRefreshToken();
        refreshToken.UserId = user.Id;

        _context.UserRefreshTokens.Add(refreshToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token,
        };
    }
}
