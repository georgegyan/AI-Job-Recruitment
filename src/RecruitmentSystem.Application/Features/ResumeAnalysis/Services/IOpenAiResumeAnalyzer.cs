namespace RecruitmentSystem.Application.Features.ResumeAnalysis.Services;

public interface IOpenAiResumeAnalyzer
{
    Task<string> AnalyzeAsync(string resumeText);
}