using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using MediatR;

namespace Bookstore.Application.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
{
    private readonly IBookstoreDbContext _dbContext;

    public DeleteAuthorCommandHandler(IBookstoreDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteAuthorCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Authors
            .FindAsync([request.Id], cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Author), request.Id);
        }

        _dbContext.Authors.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
