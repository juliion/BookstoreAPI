namespace BookstoreAPI.Models.Author;

public class CreateAuthorModel
{
    public required string Name { get; set; }
    public string? Bio { get; set; }
    public string? Nationality { get; set; }
}
