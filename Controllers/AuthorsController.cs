using LibraryCatalogAPI.Models.DTOs.Create;
using LibraryCatalogAPI.Services.Interfaces;
using LibraryCatalogAPI.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCatalogAPI.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly CreateAuthorValidator _validator;


    public AuthorsController(IAuthorService authorService, CreateAuthorValidator validator)
    {
        _authorService = authorService;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await _authorService.GetAllAuthorsAsync();
        return Ok(authors);
    }

    [Authorize(Roles = "Admin, Librarian")]
    [HttpPost]
    public async Task<IActionResult> Create(CreateAuthorDto authorDto)
    {
        var validation = _validator.Validate(authorDto);
        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }
        var createdAuthor = await _authorService.CreateAuthorAsync(authorDto);
        return Ok(createdAuthor);
    }

    [Authorize(Roles = "Admin, Librarian")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _authorService.DeleteAsync(id);
        return NoContent();
    }
}