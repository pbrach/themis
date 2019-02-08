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
            optionsBuilder.UseSqlite("Data Source=../persistence/themis.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chore>().HasData(
                new Chore {Id = 1, Title = "Establish World Domination", Description = "Ask Pinky and Brain for details!"},
                new Chore {Id = 2, Title = "World Peace", Description = "Once you dominate all, declare world peace"},
                new Chore {Id = 3, Title = "Go Fishing", Description = "Take your fishing rod and decoys and get some fish."}
            );
        }
    }
}