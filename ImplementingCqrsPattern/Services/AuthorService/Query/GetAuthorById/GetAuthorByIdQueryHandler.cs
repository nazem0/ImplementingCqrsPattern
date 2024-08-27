using ImplementingCqrsPattern.DTOs.OutputDTOs.AuthorDTOs;
using ImplementingCqrsPattern.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ImplementingCqrsPattern.Services.AuthorService.Query.GetAuthorById
{
    public class GetAuthorByIdQueryHandler(AppDbContext dbContext) :
        IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdRequestDTO?>
    {
        public async Task<GetAuthorByIdRequestDTO?> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            //using var sqlConnection = dbContext.Database.GetDbConnection();
            //using SqlConnection sqlConnection = new(settings.ConnectionString);
            //string query = $"SELECT * FROM {nameof(Author)} WHERE Id = @Id";
            //GetAuthorByIdRequestDTO? author = await sqlConnection.QueryFirstOrDefaultAsync<GetAuthorByIdRequestDTO>(query, new { request.Id });
            GetAuthorByIdRequestDTO? author =
                await
                dbContext
                .Authors
                .Include(e => e.Books)
                .Select(e =>
                     new GetAuthorByIdRequestDTO(
                        e.Id,
                        e.Name,
                        e.Books
                        .Select(b =>
                            new BookDTO(b.Id, b.Name, b.ISBN, b.PublishDate, b.Copies, b.Price))))
                .FirstOrDefaultAsync(cancellationToken);
            if (author == null) return null;
            return author;
        }
    }
}
