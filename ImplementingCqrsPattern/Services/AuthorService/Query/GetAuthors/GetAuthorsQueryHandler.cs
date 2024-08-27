using ImplementingCqrsPattern.DTOs.OutputDTOs.AuthorDTOs;
using ImplementingCqrsPattern.Entities;
using ImplementingCqrsPattern.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ImplementingCqrsPattern.Services.AuthorService.Query.GetAuthors
{
    public class GetAuthorsQueryHandler(AppDbContext dbContext) :
        IRequestHandler<GetAuthorsQuery, IEnumerable<GetAuthorsRequestDTO>>
    {
        public async Task<IEnumerable<GetAuthorsRequestDTO>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            //using var sqlConnection = dbContext.Database.GetDbConnection();
            //using SqlConnection sqlConnection = new(settings.ConnectionString);
            //string query = $"SELECT * FROM {nameof(Author)}";
            //IEnumerable<GetAuthorsRequestDTO> authors = await sqlConnection.QueryAsync<GetAuthorsRequestDTO>(query);
            return await dbContext.Authors.Select(e => new GetAuthorsRequestDTO(e.Id, e.Name)).ToListAsync(cancellationToken);
        }
    }
}
