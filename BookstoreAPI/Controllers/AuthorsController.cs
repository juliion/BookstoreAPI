using AutoMapper;
using Bookstore.Application.Authors.Commands.CreateAuthor;
using Bookstore.Application.Authors.Commands.DeleteAuthor;
using Bookstore.Application.Authors.Queries.GetAuthorDetails;
using Bookstore.Application.Authors.Queries.GetAuthors;
using Bookstore.Domain.Constants;
using BookstoreAPI.Models.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers;

[Route("api/[controller]")]
public class AuthorsController : BaseController
{
    private readonly IMapper _mapper;

    public AuthorsController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet("GetAuthors")]
    public async Task<ActionResult<AuthorsListVM>> GetAuthors()
    {
        var command = new GetAuthorsQuery();
        var authorsList = await Mediator.Send(command);
        return Ok(authorsList);
    }

    [HttpGet("GetAuthorDetails")]
    public async Task<ActionResult<AuthorDetailsVM>> GetAuthorDetails(Guid id)
    {
        var command = new GetAuthorDetailsQuery { Id = id };
        var author = await Mediator.Send(command);
        return Ok(author);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost("CreateAuthor")]
    public async Task<ActionResult<Guid>> CreateAuthor(CreateAuthorModel createAuthor)
    {
        var command = _mapper.Map<CreateAuthorCommand>(createAuthor);
        var id = await Mediator.Send(command);
        return Ok(id);
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("DeleteAuthor")]
    public async Task<ActionResult> DeleteAuthor(Guid id)
    {
        var command = new DeleteAuthorCommand { Id = id };
        await Mediator.Send(command);
        return Ok();
    }
}

