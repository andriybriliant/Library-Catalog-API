using LibraryCatalogAPI.Data;
using LibraryCatalogAPI.Models.DTOs;
using LibraryCatalogAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryCatalogAPI.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(IConfiguration configuration, AppDbContext context)
    {
        _context = context;
    }

    public async Task DeleteUserAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with username {username} not found");
        }
        _context.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<UserDto> GetCurrentUserAsync(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
        {
            throw new KeyNotFoundException($"User with username {username} not found");
        }
        return new UserDto { Id = user.Id, NameSurname = user.NameSurname, Username = user.Username, Role = user.Role };
    }
}