using LibraryCatalogAPI.Models.DTOs;
using LibraryCatalogAPI.Services;
using LibraryCatalogAPI.Services.Interfaces;
using LibraryCatalogAPI.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthservice _authService;
    private readonly RegisterValidator _registerValidator;
    private readonly LoginValidator _loginValidator;

    public AuthController(IAuthservice authService, RegisterValidator registerValidator, LoginValidator loginValidator)
    {
        _authService = authService;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var validation = _registerValidator.Validate(registerDto);
        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }
        var success = await _authService.RegisterAsync(registerDto);
        if (!success) return BadRequest("Username already exists.");
        return Ok("User registered successfully.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var validation = _loginValidator.Validate(loginDto);
        if(!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }

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

    [Authorize(Roles = "Admin")]
    [HttpPost("register-librarian")]
    public async Task<IActionResult> RegisterLibrarian([FromBody] RegisterDto registerDto)
    {
        var success = await _authService.RegisterAsync(registerDto, true);
        if (!success) return BadRequest("Username already exists.");
        return Ok("Librarian registered successfully.");
    }
}