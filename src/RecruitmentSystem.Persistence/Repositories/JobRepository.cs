using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Persistence.Context;

namespace RecruitmentSystem.Persistence.Repositories;

public class JobRepository : Repository<Job>, IJobRepository
{
    private new readonly ApplicationDbContext _context;

    public JobRepository(ApplicationDbContext context)
        : base(context)
    {
        _context = context;
    }

    public new async Task<Job?> GetByIdAsync(Guid id)
    {
        return await _context.Jobs
            .Include(j => j.Company)
            .FirstOrDefaultAsync(j => j.Id == id);
    }

    public new async Task<List<Job>> GetAllAsync()
    {
        return await _context.Jobs
            .Include(j => j.Company)
            .ToListAsync();
    }

    public void Remove(Job job)
    {
        _context.Jobs.Remove(job);
    }
}