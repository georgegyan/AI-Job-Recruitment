using RecruitmentSystem.Application.Features.Resumes.Responses;
using Microsoft.AspNetCore.Http;

namespace RecruitmentSystem.Application.Features.Resumes.Services;

public interface IResumeService
{
    Task<ResumeResponse> UploadAsync(
        Guid candidateId,
        IFormFile file);

    Task<List<ResumeResponse>>
        GetCandidateResumesAsync(Guid candidateId);
}
