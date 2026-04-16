namespace LibraryCatalogAPI.Models.DTOs.Create;

public class CreateBookDto
{
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public Guid AuthorId { get; set; }
}