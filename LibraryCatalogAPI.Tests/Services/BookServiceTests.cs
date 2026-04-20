using FluentAssertions;
using LibraryCatalogAPI.Data;
using LibraryCatalogAPI.Models;
using LibraryCatalogAPI.Models.DTOs;
using LibraryCatalogAPI.Models.DTOs.Create;
using LibraryCatalogAPI.Services;
using Microsoft.EntityFrameworkCore;


namespace LibraryCatalogAPI.Tests.Services;

public class BookServiceTests
{
    private AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid().ToString()).Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task CreateBookAsync_ReturnsCreatedBook()
    {
        var context = GetInMemoryDbContext();
        var service = new BookService(context);
        var authorId = Guid.NewGuid();

        var createDto = new CreateBookDto { Title = "Test Book", ISBN = "0-7554-9157-2", AuthorId = authorId };

        var result = await service.CreateBookAsync(createDto);

        result.Should().NotBeNull();
        result.Title.Should().Be("Test Book");
        result.ISBN.Should().Be("0-7554-9157-2");
        result.AuthorId.Should().Be(authorId);
        result.IsAvailable.Should().Be(true);
    }

    [Fact]
    public async Task UpdateBookAsync_ReturnsUpdatedBook_WhenBookExists()
    {
        var context = GetInMemoryDbContext();
        var service = new BookService(context);
        var bookId = Guid.NewGuid();
        var authorId = Guid.NewGuid();
        
        context.Books.Add(new Book { Id = bookId, Title = "Old Title", ISBN = "0-7554-9157-2", AuthorId = authorId });
        await context.SaveChangesAsync();

        var updateDto = new CreateBookDto { Title = "New Title", ISBN = "0-7434-3164-2", AuthorId = authorId };

        var result = await service.UpdateBookAsync(bookId, updateDto);

        result.Should().NotBeNull();
        result.Title.Should().Be("New Title");
        result.ISBN.Should().Be("0-7434-3164-2");
    }

    [Fact]
    public async Task UpdateBookAsync_ReturnsNull_WhenBookDoesNotExist()
    {
        var context = GetInMemoryDbContext();
        var service = new BookService(context);
        var bookId = Guid.NewGuid();
        var authorId = Guid.NewGuid();

        var updateDto = new CreateBookDto { Title = "New Title", ISBN = "0-7434-3164-2", AuthorId = authorId };

        var result = await service.UpdateBookAsync(bookId, updateDto);
        result.Should().BeNull(); 
    }

    [Fact]
    public async Task GetByIdAsync_ReturnsBook_WhenBookExists()
    {
        var context = GetInMemoryDbContext();
        var service = new BookService(context);
        var bookId = Guid.NewGuid();
        var authorId = Guid.NewGuid();
        
        context.Books.Add(new Book { Id = bookId, Title = "Test Book", ISBN = "0-7434-3164-2", AuthorId = authorId, IsAvailable = true });

        var result = await service.GetBookByIdAsync(bookId);

        result.Should().NotBeNull();
        result.Id.Should().Be(bookId);
        result.Title.Should().Be("Test Book");
        result.ISBN.Should().Be("0-7434-3164-2");
        result.AuthorId.Should().Be(authorId);
        result.IsAvailable.Should().Be(true);
    }
}