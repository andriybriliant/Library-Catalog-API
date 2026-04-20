using LibraryCatalogAPI.Models.DTOs;

namespace LibraryCatalogAPI.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> GetCurrentUserAsync(string username);
    Task DeleteUserAsync(string username);
}