namespace Bookstore.Domain.Entities;

public class Category
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public ICollection<BookCategory> BookCategories { get; set; }
}
