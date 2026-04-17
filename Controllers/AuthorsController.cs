using LibraryCatalogAPI.Models.DTOs.Create;
using LibraryCatalogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCatalogAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await _authorService.GetAllAuthorsAsync();
        return Ok(authors);
    }

    [Authorize(Roles = "Librarian")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorDto authorDto)
    {
        var createdAuthor = await _authorService.CreateAuthorAsync(authorDto);
        return Ok(createdAuthor);
    }
}