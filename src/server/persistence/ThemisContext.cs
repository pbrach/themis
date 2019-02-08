using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace persistence
{
    public class ThemisContext : DbContext
    {
        public DbSet<Chore> Chores {get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=themis.db");
        }
    }
}