using Microsoft.Extensions.Options;
using RecruitmentSystem.Application.Features.ResumeAnalysis.Services;
using RecruitmentSystem.Infrastructure.Authentication;

namespace RecruitmentSystem.Infrastructure.Services;

public class OpenAiResumeAnalyzer : IOpenAiResumeAnalyzer
{
    private readonly OpenAiSettings _settings;

    public OpenAiResumeAnalyzer(
        IOptions<OpenAiSettings> options)
    {
        _settings = options.Value;
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
