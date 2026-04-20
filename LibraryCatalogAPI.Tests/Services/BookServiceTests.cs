using LibraryCatalogAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace LibraryCatalogAPI.Tests.Services;

public class BookServiceTests
{
    private AppDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid().ToString()).Options;
        return new AppDbContext(options);
    }
}