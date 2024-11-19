using AutoMapper;
using Bookstore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Authors.Queries.GetAuthors;

public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, AuthorsListVM>
{
    private readonly IBookstoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAuthorsQueryHandler(IBookstoreDbContext dbContext,
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<AuthorsListVM> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _dbContext.Authors.AsNoTracking().ToListAsync();

        return new AuthorsListVM { Authors = _mapper.Map<IList<AuthorVM>>(authors) };
    }
}
