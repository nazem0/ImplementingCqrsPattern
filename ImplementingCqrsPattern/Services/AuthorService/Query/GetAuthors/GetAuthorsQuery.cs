using ImplementingCqrsPattern.DTOs.OutputDTOs.AuthorDTOs;
using MediatR;

namespace ImplementingCqrsPattern.Services.AuthorService.Query.GetAuthors
{
    public record GetAuthorsQuery : IRequest<IEnumerable<GetAuthorsRequestDTO>>;
}
