using ImplementingCqrsPattern.DTOs.OutputDTOs.AuthorDTOs;
using ImplementingCqrsPattern.Entities;
using ImplementingCqrsPattern.Persistence;
using MediatR;

namespace ImplementingCqrsPattern.Services.AuthorService.Command.UpdateAuthor;

public class UpdateAuthorCommandHandler(AppDbContext _dbContext, UnitOfWork _unitOfWork) :
    IRequestHandler<UpdateAuthorCommand, GetAuthorsRequestDTO>
{
    public async Task<GetAuthorsRequestDTO> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        Author? authorDbModel = await _dbContext.Authors.FindAsync([request.Id], cancellationToken);
        ArgumentNullException.ThrowIfNull(authorDbModel, nameof(authorDbModel));
        _dbContext.Authors.Entry(authorDbModel).CurrentValues.SetValues(request.Input);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new GetAuthorsRequestDTO(authorDbModel.Id, authorDbModel.Name);
    }
}
