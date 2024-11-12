using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Interfaces;

public interface IBookstoreDbContext
{
    DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
