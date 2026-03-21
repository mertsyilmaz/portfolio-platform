using System;
using System.Collections.Generic;
using System.Text;
using Identity.Contracts.Auth;

namespace Identity.Application.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
