using AutoMapper;
using Bookstore.Application.Auth.Commands.Login;
using Bookstore.Application.Auth.Commands.Logout;
using Bookstore.Application.Auth.Commands.RefreshToken;
using Bookstore.Application.Auth.Commands.Register;
using BookstoreAPI.Models;

namespace BookstoreAPI.Mappings;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<RegisterRequestModel, RegisterCommand>();
        CreateMap<LoginRequestModel, LoginCommand>();
        CreateMap<TokenRequestModel, RefreshTokenCommand>();
        CreateMap<TokenRequestModel, LogoutCommand>();
    }
}
