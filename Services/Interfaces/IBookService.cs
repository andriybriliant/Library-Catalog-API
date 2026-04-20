using LibraryCatalogAPI.Models;
using LibraryCatalogAPI.Models.DTOs;
using LibraryCatalogAPI.Models.DTOs.Create;

namespace LibraryCatalogAPI.Services.Interfaces;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<BookDto> GetBookByIdAsync(Guid id); 
    Task<Book> CreateBookAsync(CreateBookDto dto);
    Task DeleteAsync(Guid id);
}