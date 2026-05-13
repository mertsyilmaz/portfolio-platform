using Identity.Domain.Entities;

namespace Identity.Application.Abstractions.Security
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
