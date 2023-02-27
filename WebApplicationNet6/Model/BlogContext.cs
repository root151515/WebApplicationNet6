using Microsoft.EntityFrameworkCore;
using WebApplicationNet6.Extentions;

namespace WebApplicationNet6.Model
{
    public class BlogContext : DbContext
    {
        public BlogContext() { }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(" Server=DESKTOP-3S5H9LP;Database=Blog;User ID=Ki;Password=gtrfcae86;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
