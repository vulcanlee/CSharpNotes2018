using Microsoft.EntityFrameworkCore;

namespace XamarinCore.Models
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Todo> Todos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }
    }
}
