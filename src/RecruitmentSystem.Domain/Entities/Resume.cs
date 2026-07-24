using RecruitmentSystem.Domain.Common;

namespace RecruitmentSystem.Domain.Entities;

public class Resume : AuditableEntity
{
    public string FileName { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public Guid CandidateId { get; set; }

    public User Candidate { get; set; } = null!;
}