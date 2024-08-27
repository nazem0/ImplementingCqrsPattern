using ImplementingCqrsPattern.DTOs.InputDTOs.AuthorDTOs;
using ImplementingCqrsPattern.DTOs.OutputDTOs.AuthorDTOs;
using MediatR;

namespace ImplementingCqrsPattern.Services.AuthorService.Command.UpdateAuthor;

public record UpdateAuthorCommand(int Id, UpdateAuthorRequestDTO Input) : IRequest<GetAuthorsRequestDTO>;
