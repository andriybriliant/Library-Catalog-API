using LibraryCatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryCatalogAPI.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();

        var adminExists = await context.Users.AnyAsync(u => u.Role == "Admin");
        
        if (!adminExists)
        {
            var adminUser = new User
            {
                Id = Guid.NewGuid(),
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                Role = "Admin"
            };

            context.Users.Add(adminUser);
            await context.SaveChangesAsync();
        }
    }
}