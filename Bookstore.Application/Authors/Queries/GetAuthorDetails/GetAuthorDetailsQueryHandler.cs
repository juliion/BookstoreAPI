using AutoMapper;
using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Authors.Queries.GetAuthorDetails;

public class GetAuthorDetailsQueryHandler : IRequestHandler<GetAuthorDetailsQuery, AuthorDetailsVM>
{
    private readonly IBookstoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAuthorDetailsQueryHandler(IBookstoreDbContext dbContext,
        IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<AuthorDetailsVM> Handle(GetAuthorDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Authors
            .FirstOrDefaultAsync(note =>
            note.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Author), request.Id);
        }

        return _mapper.Map<AuthorDetailsVM>(entity);
    }
}
