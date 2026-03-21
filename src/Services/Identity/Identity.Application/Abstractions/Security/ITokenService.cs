using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Abstractions.Security
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
