using File.Domain.Common;
using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace File.Infrastructure.Persistence
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options)
            : base(options)
        {
        }

        public DbSet<FileRecord> Files => Set<FileRecord>();

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

            modelBuilder.Entity<FileRecord>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.FileName).IsRequired().HasMaxLength(255);
                entity.Property(x => x.StoredFileName).IsRequired().HasMaxLength(255);
                entity.Property(x => x.ContentType).IsRequired().HasMaxLength(150);
                entity.Property(x => x.Extension).IsRequired().HasMaxLength(20);
                entity.Property(x => x.Size).IsRequired();
                entity.Property(x => x.RelativePath).IsRequired().HasMaxLength(500);
                entity.Property(x => x.FolderName).IsRequired();
                entity.Property(x => x.CreatedAt).IsRequired();
            });
        }
    }
}
