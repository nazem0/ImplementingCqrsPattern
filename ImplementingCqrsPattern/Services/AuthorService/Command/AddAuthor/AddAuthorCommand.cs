using ImplementingCqrsPattern.DTOs.InputDTOs.AuthorDTOs;
using ImplementingCqrsPattern.DTOs.OutputDTOs.AuthorDTOs;
using MediatR;

namespace ImplementingCqrsPattern.Services.AuthorService.Command.AddAuthor;

public record AddAuthorCommand(AddAuthorRequestDTO Input) : IRequest<GetAuthorsRequestDTO>;
