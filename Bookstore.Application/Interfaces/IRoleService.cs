namespace Bookstore.Application.Interfaces;

public interface IRoleService
{
    Task CreateRole(string roleName);
    Task DeleteRole(string roleName);
    Task AssignRoleToUser(Guid userId, string roleName);
    Task RemoveRoleFromUser(Guid userId, string roleName);
}
