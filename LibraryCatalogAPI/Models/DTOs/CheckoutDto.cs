namespace LibraryCatalogAPI.Models.DTOs;

public class CheckoutDto
{
    public Guid Id { get; set; }
    public string BookTitle { get; set; } = string.Empty;
    public DateTime CheckoutDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}