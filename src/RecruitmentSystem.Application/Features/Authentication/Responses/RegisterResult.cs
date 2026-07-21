namespace RecruitmentSystem.Application.Features.Authentication.Responses;

public class RegisterResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;
}