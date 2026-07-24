using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Application.Interfaces.Persistence;

public interface IResumeRepository : IRepository<Resume>
{
    Task<List<Resume>> GetByCandidateIdAsync(
        Guid candidateId);
}