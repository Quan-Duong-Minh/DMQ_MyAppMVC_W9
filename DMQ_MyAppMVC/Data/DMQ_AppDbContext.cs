using DMQ_MyAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DMQ_MyAppMVC.Data
{
    public class DMQ_AppDbContext : DbContext
    {
        public DMQ_AppDbContext(DbContextOptions<DMQ_AppDbContext> options) : base(options) { }

        public DbSet<DMQ_Category> DMQ_Categories { get; set; }
        public DbSet<DMQ_Product> DMQ_Products { get; set; }
        public DbSet<DMQ_Banner> DMQ_Banners { get; set; }
        public DbSet<DMQ_Blog> DMQ_Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DMQ_Category>()
                .HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<DMQ_Product>()
                .HasIndex(p => p.Name).IsUnique();

            modelBuilder.Entity<DMQ_Banner>()
                .HasIndex(b => b.Name).IsUnique();

            modelBuilder.Entity<DMQ_Blog>()
                .HasIndex(bl => bl.Name).IsUnique();
        }
    }
}