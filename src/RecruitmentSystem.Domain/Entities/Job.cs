using RecruitmentSystem.Domain.Common;

namespace RecruitmentSystem.Domain.Entities;

public class Job : AuditableEntity
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Requirements { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public decimal Salary { get; set; }

    public Guid CompanyId { get; set; }

    public Company Company { get; set; } = null!;
}