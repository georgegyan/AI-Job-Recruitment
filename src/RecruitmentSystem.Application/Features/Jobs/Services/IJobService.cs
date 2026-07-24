using RecruitmentSystem.Application.Features.Jobs.DTOs;
using RecruitmentSystem.Application.Features.Jobs.Responses;

namespace RecruitmentSystem.Application.Features.Jobs.Services;

public interface IJobService
{
    Task<JobResponse> CreateAsync(CreateJobRequest request);

    Task<List<JobResponse>> GetAllAsync();

    Task<JobResponse?> GetByIdAsync(Guid id);

    Task<bool> DeleteAsync(Guid id);
}