using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Domain.Constants;
using RecruitmentSystem.Persistence.Context;

namespace RecruitmentSystem.Persistence.Seed;

public static class RoleSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!context.Roles.Any())
        {
            var roles = new List<Role>
            {
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = Roles.Admin
                },

                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = Roles.Recruiter
                },

                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = Roles.Candidate
                }
            };


            await context.AddRangeAsync(roles);

            await context.SaveChangesAsync();
        }
    }
}