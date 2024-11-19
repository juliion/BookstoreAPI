using MediatR;

namespace Bookstore.Application.Authors.Queries.GetAuthorDetails;

public class GetAuthorDetailsQuery : IRequest<AuthorDetailsVM>
{
    public Guid Id { get; set; }
}