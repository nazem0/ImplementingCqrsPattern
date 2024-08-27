using ImplementingCqrsPattern.Entities;
using System.ComponentModel.DataAnnotations;

namespace ImplementingCqrsPattern.DTOs.InputDTOs.AuthorDTOs;

public record AddAuthorRequestDTO([StringLength(100)] string Name);
