using ImplementingCqrsPattern.Entities;
using System.ComponentModel.DataAnnotations;

namespace ImplementingCqrsPattern.DTOs.InputDTOs.AuthorDTOs;

public record UpdateAuthorRequestDTO([StringLength(100)] string Name);
