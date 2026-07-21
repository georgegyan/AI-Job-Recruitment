using RecruitmentSystem.Application.Features.Authentication.DTOs;
using RecruitmentSystem.Application.Features.Authentication.Responses;
using RecruitmentSystem.Application.Features.Authentication.Services;
using RecruitmentSystem.Application.Interfaces.Authentication;
using RecruitmentSystem.Application.Interfaces.Persistence;

namespace RecruitmentSystem.Infrastructure.Authentication;

public class LoginService : ILoginService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthResponse?> LoginAsync(
        LoginRequest request)
    {
        var user = await _userRepository
            .GetByEmailAsync(request.Email);

        if (user is null)
        {
            return null;
        }

        var passwordValid =
            _passwordHasher.VerifyPassword(
                request.Password,
                user.PasswordHash);

        if (!passwordValid)
        {
            return null;
        }

        var accessToken =
            _jwtTokenGenerator.GenerateAccessToken(user);

        var refreshToken =
            _jwtTokenGenerator.GenerateRefreshToken();

        return new AuthResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            Email = user.Email,
            Role = user.Role.Name
        };
    }
}