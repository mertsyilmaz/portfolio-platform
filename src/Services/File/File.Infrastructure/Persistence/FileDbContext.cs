using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace File.Infrastructure.Persistence
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options)
              : base(options)
        {
        }

        public DbSet<FileRecord> Files => Set<FileRecord>();

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
