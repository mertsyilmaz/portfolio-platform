using CV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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

            modelBuilder.Entity<Skill>(entity => { 
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(150);
                entity.Property(x => x.Level).HasMaxLength(100);
                entity.Property(x => x.Category).HasMaxLength(100);
                entity.Property(x => x.CreatedAt).IsRequired();
            
            });

            modelBuilder.Entity<PersonalInfo>(entity => {
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

                entity.Property(x => x.Platform)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(x => x.Url)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(x => x.DisplayOrder)
                    .IsRequired();

                entity.Property(x => x.CreatedAt)
                    .IsRequired();
            });
        }
    }
}
