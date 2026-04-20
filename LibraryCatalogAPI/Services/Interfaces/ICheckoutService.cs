using LibraryCatalogAPI.Models.DTOs;

namespace LibraryCatalogAPI.Services.Interfaces;

public interface ICheckoutService
{
    Task<CheckoutDto?> CheckoutBookAsync(string username, Guid bookId);
    Task<bool> ReturnBookAsync(string username, Guid checkoutId);
    Task<IEnumerable<CheckoutDto>> GetUserCheckoutsAsync(string username);
}