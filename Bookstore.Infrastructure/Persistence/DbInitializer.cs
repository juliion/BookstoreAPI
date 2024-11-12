namespace Bookstore.Infrastructure.Persistence;

public class DbInitializer
{
    public static void Initialize(BookstoreDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
