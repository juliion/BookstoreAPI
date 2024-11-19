namespace Bookstore.Application.Authors.Queries.GetAuthorDetails;

public class AuthorDetailsVM
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Bio { get; set; }
    public string? Nationality { get; set; }
}
