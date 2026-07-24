using RecruitmentSystem.Domain.Common;

namespace RecruitmentSystem.Domain.Entities;

public class ResumeAnalysis : AuditableEntity
{
    public Guid ResumeId { get; set; }

    public Resume Resume { get; set; } = null!;

    public string Skills { get; set; } = string.Empty;

    public string Education { get; set; } = string.Empty;

    public string Experience { get; set; } = string.Empty;

    public int ResumeScore { get; set; }

    public string Recommendation { get; set; } = string.Empty;
}