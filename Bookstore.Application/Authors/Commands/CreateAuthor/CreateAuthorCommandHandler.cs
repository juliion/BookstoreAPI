using Bookstore.Application.Authors.Commands.CreateAuthor;
using Bookstore.Application.Interfaces;
using Bookstore.Domain.Entities;
using MediatR;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Guid>
{
    private readonly IBookstoreDbContext _dbContext;

    public CreateAuthorCommandHandler(IBookstoreDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Guid> Handle(CreateAuthorCommand request,
        CancellationToken cancellationToken)
    {
        var author = new Author
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };

        _dbContext.Authors.Add(author);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return author.Id;
    }
}
