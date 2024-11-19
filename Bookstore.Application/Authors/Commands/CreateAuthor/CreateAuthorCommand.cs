using MediatR;

namespace Bookstore.Application.Authors.Commands.CreateAuthor;

public class CreateAuthorCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public string? Bio { get; set; }
    public string? Nationality { get; set; }
}