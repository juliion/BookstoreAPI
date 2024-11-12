using Bookstore.Application.Auth.Common;
using MediatR;

namespace Bookstore.Application.Auth.Commands.Register;

public class RegisterCommand : IRequest<AuthResponse>
{
    public required string Name { get; set; }
    public required string Surname { get; set; } 
    public required string Email { get; set; } 
    public required string PhoneNumber { get; set; } 
    public required string Password { get; set; }
}
