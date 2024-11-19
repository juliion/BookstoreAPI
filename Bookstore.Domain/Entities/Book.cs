namespace Bookstore.Domain.Entities;

public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public DateTime PublicationDate { get; set; }
    public required string Language { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? EditedAt { get; set; }
    public Guid AuthorId { get; set; }
    public Guid PublisherId { get; set; }

    public Author Author { get; set; }
    public Publisher Publisher { get; set; }
    public ICollection<BookCategory> BookCategories { get; set; }
}
