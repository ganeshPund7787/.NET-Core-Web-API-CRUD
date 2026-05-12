using Database_Connection_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Database_Connection_Practice.DataBase
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ToDo> ToDos => Set<ToDo>();
    }
}
