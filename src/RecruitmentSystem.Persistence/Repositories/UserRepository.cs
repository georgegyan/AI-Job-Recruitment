using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Persistence.Context;

namespace RecruitmentSystem.Persistence.Repositories;

public class UserRepository
    : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(
                u => u.Email == email);
    }

    public async Task<bool> ExistsAsync(string email)
    {
        return await _context.Users
            .AnyAsync(u => u.Email == email);
    }
}