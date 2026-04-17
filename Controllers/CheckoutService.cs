using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LibraryCatalogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCatalogAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CheckoutsController : ControllerBase
{
    private readonly ICheckoutService _checkoutService;

    public CheckoutsController(ICheckoutService checkoutService)
    {
        _checkoutService = checkoutService;
    }

    [HttpPost("{bookId}")]
    public async Task<IActionResult> CheckoutBook(Guid bookId)
    {
        var username = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        if (string.IsNullOrEmpty(username)) return Unauthorized();

        var result = await _checkoutService.CheckoutBookAsync(username, bookId);
        
        if (result == null) return BadRequest("Book is not available or does not exist.");

        return Ok(result);
    }

    [HttpPost("return/{checkoutId}")]
    public async Task<IActionResult> ReturnBook(Guid checkoutId)
    {
        var username = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        if (string.IsNullOrEmpty(username)) return Unauthorized();

        var success = await _checkoutService.ReturnBookAsync(username, checkoutId);
        
        if (!success) return BadRequest("Invalid return request.");

        return Ok("Book returned successfully.");
    }

    [HttpGet("my-books")]
    public async Task<IActionResult> GetMyCheckouts()
    {
        var username = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
        if (string.IsNullOrEmpty(username)) return Unauthorized();

        var checkouts = await _checkoutService.GetUserCheckoutsAsync(username);
        return Ok(checkouts);
    }
}