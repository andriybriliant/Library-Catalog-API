using LibraryCatalogAPI.Models;
using LibraryCatalogAPI.Models.DTOs;

namespace LibraryCatalogAPI.Services.Interfaces;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book> CreateBookAsync(BookDto dto);
}