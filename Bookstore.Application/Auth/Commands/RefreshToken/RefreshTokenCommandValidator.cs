using FluentValidation;

namespace Bookstore.Application.Auth.Commands.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(refreshTokenCommand => refreshTokenCommand.RefreshToken)
            .NotEmpty();
    }
}
