using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Infrastructure.Persistence
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

                entity.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200);

                entity.Property(x => x.PasswordHash)
                .IsRequired();

                entity.Property(x => x.IsActive)
                .IsRequired();

                entity.Property(x => x.CreatedAt)
                .IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(x => x.Description)
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(x => new { x.UserId, x.RoleId });

                entity.HasOne(x => x.User)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.UserId);

                entity.HasOne(x => x.Role)
                    .WithMany(x => x.UserRoles)
                    .HasForeignKey(x => x.RoleId);
            });
        }
    }
}
