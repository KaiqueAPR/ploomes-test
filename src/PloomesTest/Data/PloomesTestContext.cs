using Microsoft.EntityFrameworkCore;

namespace PloomesTest.Models;

public class PloomesTestContext : DbContext
{
    public PloomesTestContext(DbContextOptions<PloomesTestContext> options) : base(options)
    {
    }
    public DbSet<Person> People { get; set; } = null!;
}
