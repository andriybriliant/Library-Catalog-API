using LibraryCatalogAPI.Data;
using LibraryCatalogAPI.Models;
using LibraryCatalogAPI.Models.DTOs;
using LibraryCatalogAPI.Models.DTOs.Create;
using LibraryCatalogAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryCatalogAPI.Services;

public class BookService : IBookService
{
    private readonly AppDbContext _context;

    public BookService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> CreateBookAsync(CreateBookDto bookDto)
    {
        var newBook = new Book
        {
            Id = Guid.NewGuid(),
            Title = bookDto.Title,
            ISBN = bookDto.ISBN,
            AuthorId = bookDto.AuthorId,
            IsAvailable = true
        };

        _context.Books.Add(newBook);
        await _context.SaveChangesAsync();
        return newBook;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = _context.Books.FindAsync(id);
        if(entity.Result == null)
        {
            throw new KeyNotFoundException($"Book with id {id} not found");
        }

        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}