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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(x => x.Position)
                .IsRequired()
                .HasMaxLength(150);

                entity.Property(x => x.Description)
                .HasMaxLength(2000);

                entity.Property(x => x.StartDate)
                .IsRequired();

                entity.Property(x => x.IsCurrent)
                .IsRequired();

                entity.Property(x => x.CreatedAt)
                .IsRequired();


            });

        }
    }
}
