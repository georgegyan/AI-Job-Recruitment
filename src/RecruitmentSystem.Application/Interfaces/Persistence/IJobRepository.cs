using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Application.Interfaces.Persistence;

public interface IJobRepository : IRepository<Job>
{
    new Task<Job?> GetByIdAsync(Guid id);

    new Task<List<Job>> GetAllAsync();

    void Remove(Job job);
}