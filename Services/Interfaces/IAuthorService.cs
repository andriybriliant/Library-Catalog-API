using LibraryCatalogAPI.Models.DTOs;
using LibraryCatalogAPI.Models.DTOs.Create;

namespace LibraryCatalogAPI.Services.Interfaces;

public interface IAuthorService
{
    Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
    Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto authorDto);
}