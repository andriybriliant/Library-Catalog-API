using LibraryCatalogAPI.Data;
using LibraryCatalogAPI.Models;
using LibraryCatalogAPI.Models.DTOs;
using LibraryCatalogAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryCatalogAPI.Services;

public class CheckoutService : ICheckoutService
{
    private readonly AppDbContext _context;

    public CheckoutService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CheckoutDto?> CheckoutBookAsync(string username, Guid bookId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

        if (user == null || book == null || !book.IsAvailable)
        {
            return null;
        }

        var checkout = new Checkout
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            BookId = bookId,
            CheckoutDate = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(14)
        };

        book.IsAvailable = false;

        _context.Checkouts.Add(checkout);
        await _context.SaveChangesAsync();

        return new CheckoutDto
        {
            Id = checkout.Id,
            BookTitle = book.Title,
            CheckoutDate = checkout.CheckoutDate,
            DueDate = checkout.DueDate
        };
    }

    public async Task<bool> ReturnBookAsync(string username, Guid checkoutId)
    {
        var checkout = await _context.Checkouts
            .Include(c => c.Book)
            .Include(c => c.User)
            .FirstOrDefaultAsync(c => c.Id == checkoutId && c.User.Username == username);

        if (checkout == null || checkout.ReturnDate != null)
        {
            return false;
        }

        checkout.ReturnDate = DateTime.UtcNow;
        checkout.Book.IsAvailable = true;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CheckoutDto>> GetUserCheckoutsAsync(string username)
    {
        return await _context.Checkouts
            .Include(c => c.Book)
            .Where(c => c.User.Username == username)
            .Select(c => new CheckoutDto
            {
                Id = c.Id,
                BookTitle = c.Book.Title,
                CheckoutDate = c.CheckoutDate,
                DueDate = c.DueDate,
                ReturnDate = c.ReturnDate
            })
            .ToListAsync();
    }
}