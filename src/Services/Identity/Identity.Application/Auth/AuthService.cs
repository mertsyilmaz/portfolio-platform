using Identity.Contracts.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using Identity.Application.Abstractions.Persistence;
using Identity.Application.Abstractions.Security;

namespace Identity.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user is null) 
            {
                throw new Exception("User not found");
            }

            if (user.PasswordHash != request.Password)
            {
                throw new Exception("Invalid password");
            }

            var token = _tokenService.CreateToken(user);

            return new LoginResponse
            {
                AccessToken = token
            };
        }
    }
}
