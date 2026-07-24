using Microsoft.EntityFrameworkCore;
using RecruitmentSystem.Application.Interfaces.Persistence;
using System.Linq;
using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Persistence.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public IQueryable<User> Users => Set<User>();
    public IQueryable<Role> Roles => Set<Role>();
    public IQueryable<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Job> Jobs => Set<Job>();
    public DbSet<RecruitmentSystem.Domain.Entities.Application> Applications => Set<RecruitmentSystem.Domain.Entities.Application>();
    public DbSet<Resume> Resumes => Set<Resume>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly
        );
    }
}