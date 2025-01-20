using Microsoft.EntityFrameworkCore;
using PostCore.Entities;
using PostInfrastructure.Configurations;

namespace PostInfrastructure
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
    }
}
