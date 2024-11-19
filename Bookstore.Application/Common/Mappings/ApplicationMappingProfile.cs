using AutoMapper;
using Bookstore.Application.Authors.Queries.GetAuthorDetails;
using Bookstore.Application.Authors.Queries.GetAuthors;
using Bookstore.Domain.Entities;

namespace Bookstore.Application.Common.Mappings;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Author, AuthorDetailsVM>();
        CreateMap<Author, AuthorVM>();
    }
}
