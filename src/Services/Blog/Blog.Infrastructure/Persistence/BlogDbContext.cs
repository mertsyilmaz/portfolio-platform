using Blog.Domain.Common;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Persistence
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Image> Images => Set<Image>();

        public override int SaveChanges()
        {
            ApplyAuditInformation();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void ApplyAuditInformation()
        {
            var now = DateTime.UtcNow;

            var entries = ChangeTracker
                .Entries<IHasTimestamps>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = now;
                    entry.Entity.UpdatedAt = null;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(x => x.CreatedAt).IsModified = false;
                    entry.Entity.UpdatedAt = now;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.AuthorId).IsRequired();
                entity.Property(x => x.Title).IsRequired();
                entity.Property(x => x.Slug).IsRequired();
                entity.Property(x => x.Summary).IsRequired();
                entity.Property(x => x.Content).IsRequired();
                entity.Property(x => x.IsPublished).IsRequired();
                entity.Property(x => x.IsFeatured).IsRequired();
                entity.Property(x => x.DisplayOrder).IsRequired();
                entity.Property(x => x.CreatedAt).IsRequired();

                entity.HasIndex(x => x.Slug).IsUnique();

                entity.HasMany(x => x.Categories)
                    .WithMany(x => x.Posts);

                entity.HasMany(x => x.Tags)
                    .WithMany(x => x.Posts);

                entity.HasMany(x => x.Comments)
                    .WithOne(x => x.Post)
                    .HasForeignKey(x => x.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(x => x.Images)
                    .WithOne(x => x.Post)
                    .HasForeignKey(x => x.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.PostId).IsRequired();
                entity.Property(x => x.AuthorId).IsRequired();
                entity.Property(x => x.Content).IsRequired();
                entity.Property(x => x.IsApproved).IsRequired();
                entity.Property(x => x.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.PostId).IsRequired();
                entity.Property(x => x.FileId).IsRequired();
                entity.Property(x => x.UsageType).IsRequired();
                entity.Property(x => x.DisplayOrder).IsRequired();
                entity.Property(x => x.CreatedAt).IsRequired();
            });
        }
    }
}