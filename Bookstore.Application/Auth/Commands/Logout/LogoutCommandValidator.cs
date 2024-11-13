using FluentValidation;

namespace Bookstore.Application.Auth.Commands.Logout;

public class LogoutCommandValidator : AbstractValidator<LogoutCommand>
{
    public LogoutCommandValidator()
    {
        RuleFor(logoutCommand =>
            logoutCommand.UserId).NotEqual(Guid.Empty);
        RuleFor(logoutCommand => logoutCommand.RefreshToken)
            .NotEmpty();
    }
}
