using ImplementingCqrsPattern.DTOs.OutputDTOs.AuthorDTOs;
using ImplementingCqrsPattern.Entities;
using ImplementingCqrsPattern.Persistence;
using MediatR;

namespace ImplementingCqrsPattern.Services.AuthorService.Command.AddAuthor;

public class AddAuthorCommandHandler(AppDbContext _dbContext, UnitOfWork _unitOfWork) :
    IRequestHandler<AddAuthorCommand, GetAuthorsRequestDTO>
{
    public async Task<GetAuthorsRequestDTO> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        Author dbModel = new(request.Input.Name);
        _dbContext.Authors.Add(dbModel);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new GetAuthorsRequestDTO(dbModel.Id, dbModel.Name);
    }
}
