using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Common;
using Portfolio.Domain.Entities;

namespace Portfolio.Infrastructure.Persistence
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Technology> Technologies => Set<Technology>();
        public DbSet<Architecture> Architectures => Set<Architecture>();
        public DbSet<Image> Images => Set<Image>();

        public override int SaveChanges()
        {
            ApplyCreationAudit();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ApplyCreationAudit();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyCreationAudit()
        {
            var now = DateTime.UtcNow;
            var entries = ChangeTracker
                .Entries<IHasCreationTime>()
                .Where(x => x.State == EntityState.Added);

            foreach (var entry in entries)
            {
                entry.Entity.CreatedAt = now;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
                entity.Property(x => x.Summary).IsRequired();
                entity.Property(x => x.Description).IsRequired();
                entity.Property(x => x.ProjectUrl).IsRequired();
                entity.Property(x => x.GithubUrl).IsRequired();
                entity.Property(x => x.IsFeatured).IsRequired();
                entity.Property(x => x.DisplayOrder).IsRequired();
                entity.Property(x => x.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
            });

            modelBuilder.Entity<Architecture>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired();
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.FileId).IsRequired();
                entity.Property(x => x.DisplayOrder).IsRequired();
                entity.Property(x => x.IsCover).IsRequired();
                entity.Property(x => x.ProjectId).IsRequired();

                entity.HasOne(x => x.Project).WithMany(x => x.Images).HasForeignKey(x => x.ProjectId);
            });

            modelBuilder.Entity<Project>().HasMany(x => x.Categories).WithMany(x => x.Projects);
            modelBuilder.Entity<Project>().HasMany(x => x.Technologies).WithMany(x => x.Projects);
            modelBuilder.Entity<Project>().HasMany(x => x.Architectures).WithMany(x => x.Projects);
        }
    }
}
