using FluentValidation;

namespace Bookstore.Application.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(loginCommand => loginCommand.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(loginCommand => loginCommand.Password)
            .NotEmpty()
            .MinimumLength(6);
    }
}
