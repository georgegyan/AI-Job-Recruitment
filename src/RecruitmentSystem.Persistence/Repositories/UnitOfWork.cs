using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Persistence.Context;

namespace RecruitmentSystem.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context
            .SaveChangesAsync(cancellationToken);
    }
}