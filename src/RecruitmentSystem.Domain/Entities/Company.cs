using RecruitmentSystem.Domain.Common;

namespace RecruitmentSystem.Domain.Entities;

public class Company : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Website { get; set; } = string.Empty;

    public Guid RecruiterId { get; set; }

    public User Recruiter { get; set; } = null!;

    public ICollection<Job> Jobs { get; set; }
    = new List<Job>();
}