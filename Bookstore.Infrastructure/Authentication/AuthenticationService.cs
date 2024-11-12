﻿using Bookstore.Application.Auth.Commands.Login;
using Bookstore.Application.Auth.Commands.Logout;
using Bookstore.Application.Auth.Commands.Register;
using Bookstore.Application.Auth.Common;
using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Interfaces;
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

    public async Task<AuthResponse> RefreshToken(string token, CancellationToken cancellationToken)
    {
        var refreshToken = await _context.UserRefreshTokens
            .FirstOrDefaultAsync(refresh => refresh.Token == token);

        if (refreshToken == null || refreshToken.IsRevoked || refreshToken.Expires < DateTime.UtcNow)
            throw new SecurityTokenException("Unknown or invalid refresh token.");

        refreshToken.IsRevoked = true;
        var user = await _userManager.FindByIdAsync(refreshToken.UserId.ToString());
        var newRefreshToken = _tokenService.GenerateRefreshToken();
        newRefreshToken.UserId = user.Id;
        
        _context.UserRefreshTokens.Add(newRefreshToken);
        await _context.SaveChangesAsync(cancellationToken);

        var accessToken = _tokenService.GenerateAccessToken(user);

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken.Token,
        };
    }
    public async Task RevokeToken(string token, CancellationToken cancellationToken)
    {
        var refreshToken = await _context.UserRefreshTokens
            .FirstOrDefaultAsync(refresh => refresh.Token == token);

        if (refreshToken == null || refreshToken.IsRevoked)
            throw new SecurityTokenException("Invalid refresh token.");

        refreshToken.IsRevoked = true;

        await _context.SaveChangesAsync(cancellationToken);
    }

    private async Task<AuthResponse> GenerateAuthenticationResultForUser(User user, CancellationToken cancellationToken)
    {
        var accessToken = _tokenService.GenerateAccessToken(user);
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
