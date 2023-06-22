using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Repositories.Config;

namespace WebApplication11.Repositories
{
    public class Repository : DbContext
    {
        public Repository(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<book> books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }

    }
}
