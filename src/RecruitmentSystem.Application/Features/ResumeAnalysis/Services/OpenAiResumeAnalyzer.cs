using RecruitmentSystem.Application.Features.ResumeAnalysis.Services;

namespace RecruitmentSystem.Application.Features.ResumeAnalysis.Services;

public class OpenAiResumeAnalyzer : IOpenAiResumeAnalyzer
{
    public OpenAiResumeAnalyzer()
    {
    }

    public async Task<string> AnalyzeAsync(
        string resumeText)
    {
        // Temporary implementation

        await Task.CompletedTask;

        return $"""
Skills:
C#
ASP.NET Core
SQL

Education:
Bachelor Degree

Experience:
2 Years Software Development

Score:
85

Recommendation:
Strong Candidate
""";
    }
}