using Microsoft.EntityFrameworkCore;
using Primeira_API.Models;


namespace Primeira_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Personagem> DbPersonagem { get; set; }


    }
}
