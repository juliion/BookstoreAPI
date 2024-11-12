using Microsoft.AspNetCore.Identity;

namespace Bookstore.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public ICollection<UserRefreshToken> UserRefreshTokens { get; set; }

}
