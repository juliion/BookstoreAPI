using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Interfaces;

public interface IBookstoreDbContext
{
    DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    DbSet<Author> Authors { get; set; }
    DbSet<Publisher> Publishers { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Book> Books { get; set; }
    DbSet<BookCategory> BookCategories { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
