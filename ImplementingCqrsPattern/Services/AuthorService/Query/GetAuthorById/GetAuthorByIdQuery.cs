using ImplementingCqrsPattern.DTOs.OutputDTOs.AuthorDTOs;
using MediatR;

namespace ImplementingCqrsPattern.Services.AuthorService.Query.GetAuthorById
{
    public record GetAuthorByIdQuery(int Id) : IRequest<GetAuthorByIdRequestDTO?>;
}
