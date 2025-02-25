using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using PostCore.Entities;
using PostInfrastructure.Configurations;

namespace PostInfrastructure
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.ConfigureWarnings(warnings => warnings.Log(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new MediaConfiguration());
            modelBuilder.ApplyConfiguration(new ReactionConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new TopicPostConfiguration());
            modelBuilder.ApplyConfiguration(new TopicUserConfiguration());
            modelBuilder.ApplyConfiguration(new UserPostViewsConfiguration());
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<TopicPost> TopicPosts { get; set; }
        public DbSet<TopicUser> TopicUsers { get; set; }
        public DbSet<UserPostViews> UserPostViews { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
    }
}