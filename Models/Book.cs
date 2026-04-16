namespace LibraryCatalogAPI.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public Guid AuthorId { get; set; }
    public bool IsAvailable { get; set; }
}