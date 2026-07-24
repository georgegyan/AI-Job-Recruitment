using RecruitmentSystem.Application.Interfaces.Persistence;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Persistence.Context;

namespace RecruitmentSystem.Persistence.Repositories;

public class ResumeAnalysisRepository
    : Repository<ResumeAnalysis>,
      IResumeAnalysisRepository
{
    public ResumeAnalysisRepository(
        ApplicationDbContext context)
        : base(context)
    {
    }
}