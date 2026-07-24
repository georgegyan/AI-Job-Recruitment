using RecruitmentSystem.Application.Features.ResumeAnalysis.Responses;

namespace RecruitmentSystem.Application.Features.ResumeAnalysis.Services;

public interface IResumeAnalysisService
{
    Task<ResumeAnalysisResponse>
        AnalyzeResumeAsync(Guid resumeId);
}