using LibraryCatalogAPI.Models.DTOs;

namespace LibraryCatalogAPI.Services.Interfaces;

public interface IAuthservice
{
    Task<bool> RegisterAsync(RegisterDto registerDto, bool isAddLibrarian = false);
    Task<TokenResponseDto?> LoginAsync(LoginDto loginDto);
    Task<TokenResponseDto?> RefreshTokenAsync(TokenResponseDto refreshToken);
}