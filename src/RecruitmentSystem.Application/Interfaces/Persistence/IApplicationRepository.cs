using RecruitmentSystem.Domain.Entities;
using DomainApplication = RecruitmentSystem.Domain.Entities.Application;

namespace RecruitmentSystem.Application.Interfaces.Persistence;

public interface IApplicationRepository : IRepository<DomainApplication>
{
    Task<List<DomainApplication>> GetByCandidateIdAsync(Guid candidateId);

    Task<List<DomainApplication>> GetByJobIdAsync(Guid jobId);
}