using Identity.Domain.Entities;

namespace Identity.Application.Abstractions.Security
{
    public interface IPasswordService
    {
        string HashPassword(User user, string password);
        bool VerifyPassword(User user, string hashedPassword, string providedPassword);
    }
}
