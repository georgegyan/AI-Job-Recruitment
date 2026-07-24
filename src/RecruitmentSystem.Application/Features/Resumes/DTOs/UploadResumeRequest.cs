namespace RecruitmentSystem.Application.Features.Resumes.DTOs;

public class UploadResumeRequest
{
    public Guid CandidateId { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
}