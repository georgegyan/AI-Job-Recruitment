using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Application.Interfaces.Persistence;

public interface IApplicationDbContext
{
    IQueryable<User> Users { get; }

    IQueryable<Role> Roles { get; }

    IQueryable<RefreshToken> RefreshTokens { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}