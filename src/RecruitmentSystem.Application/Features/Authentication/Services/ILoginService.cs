using RecruitmentSystem.Application.Features.Authentication.DTOs;
using RecruitmentSystem.Application.Features.Authentication.Responses;

namespace RecruitmentSystem.Application.Features.Authentication.Services;

public interface ILoginService
{
    Task<AuthResponse?> LoginAsync(LoginRequest request);
}