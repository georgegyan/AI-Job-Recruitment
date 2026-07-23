namespace RecruitmentSystem.Application.Features.Companies.DTOs;

public class CreateCompanyRequest
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Website { get; set; } = string.Empty;

    public Guid RecruiterId { get; set; }
}