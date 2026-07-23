using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Application.Interfaces.Persistence;

public interface ICompanyRepository : IRepository<Company>
{
    new Task<Company?> GetByIdAsync(Guid id);

    new Task<List<Company>> GetAllAsync();
}