namespace LibraryCatalogAPI.Services.Interfaces;

public interface IUserService
{
    Task DeleteUserAsync(string username);
}