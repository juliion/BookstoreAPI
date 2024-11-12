using FluentValidation;

namespace Bookstore.Application.Auth.Commands.Logout;

public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
{
    public LogoutCommandValidator()
    {
        RuleFor(logoutCommand => logoutCommand.RefreshToken)
            .NotEmpty();
    }
}
