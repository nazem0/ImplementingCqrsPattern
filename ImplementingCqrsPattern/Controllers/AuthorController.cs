using ImplementingCqrsPattern.DTOs.InputDTOs.AuthorDTOs;
using ImplementingCqrsPattern.DTOs.OutputDTOs.AuthorDTOs;
using ImplementingCqrsPattern.Migrations;
using ImplementingCqrsPattern.Services.AuthorService.Command.AddAuthor;
using ImplementingCqrsPattern.Services.AuthorService.Command.UpdateAuthor;
using ImplementingCqrsPattern.Services.AuthorService.Query.GetAuthorById;
using ImplementingCqrsPattern.Services.AuthorService.Query.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImplementingCqrsPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GetAuthorsRequestDTO>> AddAutorAsync(AddAuthorRequestDTO input, CancellationToken cancellationToken = default)
        {
            GetAuthorsRequestDTO response = await _mediator.Send(new AddAuthorCommand(input), cancellationToken);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<GetAuthorsRequestDTO>> UpdateAuthorAsync(int id, [FromBody] UpdateAuthorRequestDTO input, CancellationToken cancellationToken = default)
        {
            GetAuthorsRequestDTO response = await _mediator.Send(new UpdateAuthorCommand(id, input), cancellationToken);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GetAuthorByIdRequestDTO>> GetAuthorByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            GetAuthorByIdRequestDTO? response = await _mediator.Send(new GetAuthorByIdQuery(id), cancellationToken);
            if (response == null) return NotFound();
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult<GetAuthorsRequestDTO>> GetAuthorsAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<GetAuthorsRequestDTO> response = await _mediator.Send(new GetAuthorsQuery(), cancellationToken);
            return Ok(response);
        }
    }
}
