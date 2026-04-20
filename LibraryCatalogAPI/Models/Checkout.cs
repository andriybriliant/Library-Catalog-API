namespace LibraryCatalogAPI.Models;

public class Checkout
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime CheckoutDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public User User { get; set; } = null!;
    public Book Book { get; set; } = null!;
}