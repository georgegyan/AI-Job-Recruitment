using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Application.Interfaces.Persistence;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken token);

    Task<RefreshToken?> GetByTokenAsync(string token);

    void Update(RefreshToken token);
}