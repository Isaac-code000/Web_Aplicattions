using Microsoft.EntityFrameworkCore;

namespace Minimal_API_futball;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<Time> Times => Set<Time>();
}