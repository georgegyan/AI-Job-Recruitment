namespace RecruitmentSystem.Application.Features.Applications.Responses;

public class ApplicationResponse
{
    public Guid Id { get; set; }

    public Guid CandidateId { get; set; }

    public Guid JobId { get; set; }

    public string Status { get; set; } = string.Empty;
}