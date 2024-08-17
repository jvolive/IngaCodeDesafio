using IngaCode.Application.DTOs;
using IngaCode.Application.Interfaces;
using IngaCode.Domain.Interfaces;

namespace IngaCode.Application.Services;
public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthenticationService(IUserRepository userRepository, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        var user = await _userRepository.GetByUsernameAsync(username);

        if (user != null && await _userRepository.VerifyUserPasswordAsync(username, password))
        {
            var userDto = new UserDto
            {
                UserName = user.UserName
            };

            return _jwtTokenService.GenerateToken(userDto);
        }

        throw new UnauthorizedAccessException("Invalid credentials");
    }
}