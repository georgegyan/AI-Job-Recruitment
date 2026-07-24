using RecruitmentSystem.Domain.Common;

namespace RecruitmentSystem.Domain.Entities;

public class Application : AuditableEntity
{
    public Guid CandidateId { get; set; }

    public User Candidate { get; set; } = null!;

    public Guid JobId { get; set; }

    public Job Job { get; set; } = null!;

    public string Status { get; set; } = "Pending";
}