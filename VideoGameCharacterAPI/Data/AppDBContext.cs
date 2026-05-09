using Microsoft.EntityFrameworkCore;
using VideoGameCharacterAPI.Models;

namespace VideoGameCharacterAPI.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
         public DbSet<Character> Characters => Set<Character>();
    }
}
