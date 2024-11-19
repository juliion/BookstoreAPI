using MediatR;

namespace Bookstore.Application.Authors.Queries.GetAuthors;

public class GetAuthorsQuery : IRequest<AuthorsListVM>
{
}
