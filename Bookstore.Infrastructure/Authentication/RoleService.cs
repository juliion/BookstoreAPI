using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.Infrastructure.Authentication;

public class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<User> _userManager;

    public RoleService(RoleManager<Role> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task CreateRole(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
            throw new ConflictException($"Role '{roleName}' already exists.");

        var result = await _roleManager.CreateAsync(new Role { Name = roleName });

        if (!result.Succeeded)
            throw new ApplicationException($"Failed to create role: {string.Join(", ", result.Errors)}");
    }

    public async Task DeleteRole(string roleName)
    {
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
            throw new NotFoundException($"Role '{roleName}' does not exist.");

        var result = await _roleManager.DeleteAsync(role);

        if (!result.Succeeded)
            throw new ApplicationException($"Failed to delete role: {string.Join(", ", result.Errors)}");
    }

    public async Task AssignRoleToUser(Guid userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            throw new NotFoundException("User not found.");

        if (!await _roleManager.RoleExistsAsync(roleName))
            throw new NotFoundException($"Role '{roleName}' does not exist.");

        var result = await _userManager.AddToRoleAsync(user, roleName);

        if (!result.Succeeded)
            throw new ApplicationException($"Failed to assign role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
    }

    public async Task RemoveRoleFromUser(Guid userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            throw new NotFoundException("User not found.");

        if (!await _roleManager.RoleExistsAsync(roleName))
            throw new NotFoundException($"Role '{roleName}' does not exist.");

        var result = await _userManager.RemoveFromRoleAsync(user, roleName);

        if (!result.Succeeded)
            throw new ApplicationException($"Failed to remove role: {string.Join(", ", result.Errors)}");
    }
}
