using ForumDemoApp.Data.Configure;
using ForumDemoApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ForumDemoApp.Data
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostConfiguration());
            builder.Entity<Post>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }

    }
}
