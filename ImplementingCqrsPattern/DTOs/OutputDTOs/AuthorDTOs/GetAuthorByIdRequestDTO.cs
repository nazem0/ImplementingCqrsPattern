using ImplementingCqrsPattern.Entities;

namespace ImplementingCqrsPattern.DTOs.OutputDTOs.AuthorDTOs;

public record GetAuthorByIdRequestDTO(int Id, string Name, IEnumerable<BookDTO> Books);
public record BookDTO(int Id, string Name, string ISBN, DateTime PublishDate, int Copies, float Price);
