using RecruitmentSystem.Application.Features.Authentication.Commands.Register;
using RecruitmentSystem.Application.Features.Authentication.Responses;

namespace RecruitmentSystem.Application.Features.Authentication.Services;

public interface IRegisterService
{
    Task<RegisterResult> RegisterAsync(RegisterCommand command);
}