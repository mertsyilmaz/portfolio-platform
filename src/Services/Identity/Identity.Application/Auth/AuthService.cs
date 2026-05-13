using Identity.Application.Abstractions.Persistence;
using Identity.Application.Abstractions.Security;
using Identity.Application.Common.Exceptions;
using Identity.Contracts.Auth;

namespace Identity.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public AuthService(
            IUserRepository userRepository,
            IPasswordService passwordService,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            Guard.AgainstUnauthorized(user is not null, ErrorMessages.InvalidCredentials);
            Guard.AgainstUnauthorized(user!.IsActive, ErrorMessages.InvalidCredentials);

            var passwordVerified = _passwordService.VerifyPassword(user, user.PasswordHash, request.Password);
            Guard.AgainstUnauthorized(passwordVerified, ErrorMessages.InvalidCredentials);

            var token = _tokenService.CreateToken(user);

            return new LoginResponse
            {
                AccessToken = token
            };
        }
    }
}
