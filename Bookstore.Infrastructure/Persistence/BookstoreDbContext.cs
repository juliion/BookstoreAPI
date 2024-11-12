using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Infrastructure.Persistence.EntityTypeConfigurations;
using Bookstore.Infrastucture.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Persistence;

public class BookstoreDbContext : IdentityDbContext<User, Role, Guid>, IBookstoreDbContext
{
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    public BookstoreDbContext(DbContextOptions<BookstoreDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new UserRefreshTokenConfiguration());
    }
}
