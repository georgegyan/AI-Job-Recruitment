using RecruitmentSystem.Application.Features.Applications.DTOs;
using RecruitmentSystem.Application.Features.Applications.Responses;

namespace RecruitmentSystem.Application.Features.Applications.Services;

public interface IApplicationService
{
    Task<ApplicationResponse> ApplyAsync(
        ApplyJobRequest request);

    Task<List<ApplicationResponse>>
        GetCandidateApplicationsAsync(
            Guid candidateId);

    Task<List<ApplicationResponse>>
        GetJobApplicationsAsync(
            Guid jobId);
}