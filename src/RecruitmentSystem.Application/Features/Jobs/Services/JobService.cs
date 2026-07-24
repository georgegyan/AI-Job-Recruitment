using RecruitmentSystem.Application.Features.Jobs.DTOs;
using RecruitmentSystem.Application.Features.Jobs.Responses;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Application.Features.Jobs.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IUnitOfWork _unitOfWork;

    public JobService(
        IJobRepository jobRepository,
        IUnitOfWork unitOfWork)
    {
        _jobRepository = jobRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<JobResponse> CreateAsync(
        CreateJobRequest request)
    {
        var job = new Job
        {
            Title = request.Title,
            Description = request.Description,
            Requirements = request.Requirements,
            Location = request.Location,
            Salary = request.Salary,
            CompanyId = request.CompanyId
        };

        await _jobRepository.AddAsync(job);

        await _unitOfWork.SaveChangesAsync();

        return new JobResponse
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            Location = job.Location,
            Salary = job.Salary
        };
    }

    public async Task<List<JobResponse>> GetAllAsync()
    {
        var jobs = await _jobRepository.GetAllAsync();

        return jobs.Select(j => new JobResponse
        {
            Id = j.Id,
            Title = j.Title,
            Description = j.Description,
            Location = j.Location,
            Salary = j.Salary
        }).ToList();
    }

    public async Task<JobResponse?> GetByIdAsync(Guid id)
    {
        var job = await _jobRepository.GetByIdAsync(id);

        if (job == null)
            return null;

        return new JobResponse
        {
            Id = job.Id,
            Title = job.Title,
            Description = job.Description,
            Location = job.Location,
            Salary = job.Salary
        };
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var job = await _jobRepository.GetByIdAsync(id);

        if (job == null)
            return false;

        _jobRepository.Remove(job);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}