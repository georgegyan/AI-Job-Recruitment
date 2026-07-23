using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Persistence.Context;

namespace RecruitmentSystem.Persistence.Repositories;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public new async Task<Company?> GetByIdAsync(Guid id)
    {
        return await _context.Companies
            .Include(c => c.Recruiter)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public new async Task<List<Company>> GetAllAsync()
    {
        return await _context.Companies
            .Include(c => c.Recruiter)
            .ToListAsync();
    }
}