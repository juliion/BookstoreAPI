namespace Bookstore.Domain.Entities;

public class Publisher
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Book> Books { get; set; }
}
