using Identity.Application.Abstractions.Security;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Seed
{
    public static class IdentityDataSeeder
    {
        public static async Task SeedAsync(IdentityDbContext context, IPasswordService passwordService)
        {
            if (await context.Users.AnyAsync())
            {
                return;
            }

            var adminRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                Description = "System Administrator"
            };

            var adminUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@portfolio.com",
                IsActive = true
            };

            adminUser.PasswordHash = passwordService.HashPassword(adminUser, "12345");

            var userRole = new UserRole
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            };

            await context.Roles.AddAsync(adminRole);
            await context.Users.AddAsync(adminUser);
            await context.UserRoles.AddAsync(userRole);

            await context.SaveChangesAsync();
        }
    }
}
