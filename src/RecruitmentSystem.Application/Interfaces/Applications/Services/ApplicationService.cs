using RecruitmentSystem.Application.Features.Applications.DTOs;
using RecruitmentSystem.Application.Features.Applications.Responses;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Domain.Entities;
using DomainApplication = RecruitmentSystem.Domain.Entities.Application;

namespace RecruitmentSystem.Application.Features.Applications.Services;

public class ApplicationService
    : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationService(
        IApplicationRepository applicationRepository,
        IUnitOfWork unitOfWork)
    {
        _applicationRepository = applicationRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApplicationResponse>
        ApplyAsync(ApplyJobRequest request)
    {
        var application = new DomainApplication
        {
            CandidateId = request.CandidateId,
            JobId = request.JobId,
            Status = "Pending"
        };

        await _applicationRepository.AddAsync(application);

        await _unitOfWork.SaveChangesAsync();

        return new ApplicationResponse
        {
            Id = application.Id,
            CandidateId = application.CandidateId,
            JobId = application.JobId,
            Status = application.Status
        };
    }

    public async Task<List<ApplicationResponse>>
        GetCandidateApplicationsAsync(Guid candidateId)
    {
        var applications =
            await _applicationRepository
                .GetByCandidateIdAsync(candidateId);

        return applications.Select(a =>
            new ApplicationResponse
            {
                Id = a.Id,
                CandidateId = a.CandidateId,
                JobId = a.JobId,
                Status = a.Status
            }).ToList();
    }

    public async Task<List<ApplicationResponse>>
        GetJobApplicationsAsync(Guid jobId)
    {
        var applications =
            await _applicationRepository
                .GetByJobIdAsync(jobId);

        return applications.Select(a =>
            new ApplicationResponse
            {
                Id = a.Id,
                CandidateId = a.CandidateId,
                JobId = a.JobId,
                Status = a.Status
            }).ToList();
    }
}