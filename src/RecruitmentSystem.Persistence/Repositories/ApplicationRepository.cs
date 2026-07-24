using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Persistence.Context;
using DomainApplication = RecruitmentSystem.Domain.Entities.Application;

namespace RecruitmentSystem.Persistence.Repositories;

public class ApplicationRepository
    : Repository<DomainApplication>, IApplicationRepository
{
    public ApplicationRepository(
        ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<List<DomainApplication>>
        GetByCandidateIdAsync(Guid candidateId)
    {
        return await _context.Applications
            .Include(a => a.Job)
            .Where(a => a.CandidateId == candidateId)
            .ToListAsync();
    }

    public async Task<List<DomainApplication>>
        GetByJobIdAsync(Guid jobId)
    {
        return await _context.Applications
            .Include(a => a.Candidate)
            .Where(a => a.JobId == jobId)
            .ToListAsync();
    }
}