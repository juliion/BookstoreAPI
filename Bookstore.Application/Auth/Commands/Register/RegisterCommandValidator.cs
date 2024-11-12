using FluentValidation;

namespace Bookstore.Application.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(registerCommand => registerCommand.Name)
           .NotEmpty()
           .MaximumLength(100);
        RuleFor(registerCommand => registerCommand.Surname)
           .NotEmpty()
           .MaximumLength(100);
        RuleFor(registerCommand => registerCommand.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(registerCommand => registerCommand.PhoneNumber)
           .NotEmpty()
           .MaximumLength(13);
        RuleFor(registerCommand => registerCommand.Password)
            .NotEmpty()
            .MinimumLength(6);
    }
}
