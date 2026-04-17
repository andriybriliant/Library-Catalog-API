namespace LibraryCatalogAPI.Models.DTOs;

public class RegisterDto
{
    public string NameSurname { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = "Member";
}