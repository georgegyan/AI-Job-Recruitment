namespace RecruitmentSystem.Application.Features.ResumeAnalysis.Responses;

public class ResumeAnalysisResponse
{
    public string Skills { get; set; } = string.Empty;

    public string Education { get; set; } = string.Empty;

    public string Experience { get; set; } = string.Empty;

    public int ResumeScore { get; set; }

    public string Recommendation { get; set; } = string.Empty;
}