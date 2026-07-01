using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Application.Interfaces.Persistence;

public interface IRoleRepository
{
    Task<Role?> GetByNameAsync(string roleName);

    Task<Role?> GetByIdAsync(Guid id);
}