using LibraryCatalogAPI.Models.DTOs;
using LibraryCatalogAPI.Services;
using LibraryCatalogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthservice _authService;

    public AuthController(IAuthservice authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var success = await _authService.RegisterAsync(registerDto);
        if (!success) return BadRequest("Username already exists.");
        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var tokenModel = await _authService.LoginAsync(loginDto);
        if (tokenModel == null) return Unauthorized("Invalid username or password.");
        return Ok(tokenModel);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] TokenResponseDto tokenModel)
    {
        var newTokenModel = await _authService.RefreshTokenAsync(tokenModel);
        if (newTokenModel == null) return Unauthorized("Invalid client request.");
        return Ok(newTokenModel);
    }
}