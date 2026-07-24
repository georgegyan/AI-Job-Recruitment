using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Persistence.Context;

namespace RecruitmentSystem.Persistence.Repositories;

public class ResumeRepository
    : Repository<Resume>, IResumeRepository
{
    private new readonly ApplicationDbContext _context;

    public ResumeRepository(
        ApplicationDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<List<Resume>>
        GetByCandidateIdAsync(Guid candidateId)
    {
        return await _context.Resumes
            .Where(r => r.CandidateId == candidateId)
            .ToListAsync();
    }
}