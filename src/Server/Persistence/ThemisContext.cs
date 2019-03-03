using Microsoft.EntityFrameworkCore;
using Persistence.DbTypes;

namespace Persistence
{
    public class ThemisContext : DbContext
    {
        public ThemisContext(DbContextOptions<ThemisContext> options)
        :base(options)
        {
            
        }
        public DbSet<DbChore> Chores {get; set; }
        public DbSet<DbPlan> Plans {get; set; }
        
        
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseSqlite("Data Source=../Persistence/themis.db;");
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<DbChore>().HasData(
//                new DbChore {Id = 1, Title = "Establish World Domination", Description = "Ask Pinky and Brain for details!"},
//                new DbChore {Id = 2, Title = "World Peace", Description = "Once you dominate all, declare world peace"},
//                new DbChore {Id = 3, Title = "Go Fishing", Description = "Take your fishing rod and decoys and get some fish."}
//            );
//        }
    }
}