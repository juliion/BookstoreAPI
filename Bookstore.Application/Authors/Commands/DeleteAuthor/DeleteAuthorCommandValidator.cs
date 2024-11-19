using FluentValidation;

namespace Bookstore.Application.Authors.Commands.DeleteAuthor;

public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
{
    public DeleteAuthorCommandValidator()
    {
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
    }
}
