using MediatR;

namespace Bookstore.Application.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommand : IRequest
{
    public Guid Id { get; set; }
}
