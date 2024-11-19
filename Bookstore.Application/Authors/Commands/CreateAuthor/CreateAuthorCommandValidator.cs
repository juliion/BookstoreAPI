using FluentValidation;

namespace Bookstore.Application.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
    }
}
