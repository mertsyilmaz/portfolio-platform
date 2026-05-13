using CV.Domain.Common;
using CV.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure.Persistence
{
    public class CvDbContext : DbContext
    {
        public CvDbContext(DbContextOptions<CvDbContext> options) : base(options)
        {
        }

        public DbSet<Experience> Experiences => Set<Experience>();
        public DbSet<Education> Educations => Set<Education>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<PersonalInfo> PersonalInfos => Set<PersonalInfo>();
        public DbSet<SocialLink> SocialLinks => Set<SocialLink>();
        public DbSet<Language> Languages => Set<Language>();
        public DbSet<Certificate> Certificates => Set<Certificate>();
        public DbSet<Hobby> Hobbies => Set<Hobby>();

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

            foreach (var entry in ChangeTracker.Entries<IHasCreationTime>().Where(x => x.State == EntityState.Added))
            {
                entry.Entity.CreatedAt = now;
            }

            foreach (var entry in ChangeTracker.Entries<IHasTimestamps>().Where(x => x.State == EntityState.Added))
            {
                entry.Entity.UpdatedAt = now;
            }

            foreach (var entry in ChangeTracker.Entries<IHasTimestamps>().Where(x => x.State == EntityState.Modified))
            {
                entry.Property(x => x.CreatedAt).IsModified = false;
                entry.Entity.UpdatedAt = now;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.CompanyName).IsRequired().HasMaxLength(200);
                entity.Property(x => x.Position).IsRequired().HasMaxLength(150);
                entity.Property(x => x.Description).HasMaxLength(2000);
                entity.Property(x => x.StartDate).IsRequired();
                entity.Property(x => x.IsCurrent).IsRequired();
                entity.Property(x => x.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.SchoolName).IsRequired().HasMaxLength(200);
                entity.Property(x => x.Department).IsRequired().HasMaxLength(150);
                entity.Property(x => x.Degree).IsRequired().HasMaxLength(100);
                entity.Property(x => x.Description).IsRequired().HasMaxLength(2000);
                entity.Property(x => x.StartDate).IsRequired();
                entity.Property(x => x.IsCurrent).IsRequired();
                entity.Property(x => x.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(150);
                entity.Property(x => x.Level).HasMaxLength(100);
                entity.Property(x => x.Category).HasMaxLength(100);
                entity.Property(x => x.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<PersonalInfo>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(x => x.LastName).IsRequired().HasMaxLength(100);
                entity.Property(x => x.Title).HasMaxLength(150);
                entity.Property(x => x.Summary).HasMaxLength(4000);
                entity.Property(x => x.Email).IsRequired().HasMaxLength(200);
                entity.Property(x => x.Phone).HasMaxLength(50);
                entity.Property(x => x.Location).HasMaxLength(200);
                entity.Property(x => x.CreatedAt).IsRequired();
                entity.Property(x => x.UpdatedAt).IsRequired();
            });

            modelBuilder.Entity<SocialLink>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Platform).IsRequired().HasMaxLength(100);
                entity.Property(x => x.Url).IsRequired().HasMaxLength(500);
                entity.Property(x => x.DisplayOrder).IsRequired();
                entity.Property(x => x.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(100);
                entity.Property(x => x.Level).HasMaxLength(100);
                entity.Property(x => x.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(200);
                entity.Property(x => x.Issuer).IsRequired().HasMaxLength(200);
                entity.Property(x => x.IssuedDate).IsRequired();
                entity.Property(x => x.CredentialId).HasMaxLength(200);
                entity.Property(x => x.CredentialUrl).HasMaxLength(500);
                entity.Property(x => x.CreatedAt).IsRequired();
            });

            modelBuilder.Entity<Hobby>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(150);
                entity.Property(x => x.Description).HasMaxLength(2000);
                entity.Property(x => x.CreatedAt).IsRequired();
            });
        }
    }
}
