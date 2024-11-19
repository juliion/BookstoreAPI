namespace Bookstore.Application.Authors.Queries.GetAuthors;

public class AuthorVM
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}
