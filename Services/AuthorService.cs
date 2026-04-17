using LibraryCatalogAPI.Data;
using LibraryCatalogAPI.Models;
using LibraryCatalogAPI.Models.DTOs;
using LibraryCatalogAPI.Models.DTOs.Create;
using LibraryCatalogAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryCatalogAPI.Services;

public class AuthorService : IAuthorService
{
    private readonly AppDbContext _context;

    public AuthorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
    {
        return await _context.Authors
            .Select(a => new AuthorDto 
            { 
                Id = a.Id, 
                Name = a.Name, 
                Biography = a.Biography 
            })
            .ToListAsync();
    }

    public async Task<AuthorDto> CreateAuthorAsync(CreateAuthorDto authorDto)
    {
        var author = new Author
        {
            Id = Guid.NewGuid(),
            Name = authorDto.Name,
            Biography = authorDto.Biography
        };

        _context.Authors.Add(author);
        await _context.SaveChangesAsync();

        return new AuthorDto { Id = author.Id, Name = author.Name, Biography = author.Biography };
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = _context.Authors.FindAsync(id);
        if(entity.Result == null)
        {
            throw new KeyNotFoundException($"Author with id {id} not found");
        }

        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}