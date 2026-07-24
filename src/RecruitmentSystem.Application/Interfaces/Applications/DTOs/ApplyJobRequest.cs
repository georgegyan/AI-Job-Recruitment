namespace RecruitmentSystem.Application.Features.Applications.DTOs;

public class ApplyJobRequest
{
    public Guid CandidateId { get; set; }

    public Guid JobId { get; set; }
}