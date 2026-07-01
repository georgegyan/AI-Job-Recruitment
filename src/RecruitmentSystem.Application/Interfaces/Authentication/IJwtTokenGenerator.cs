using RecruitmentSystem.Domain.Entities;
namespace RecruitmentSystem.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}