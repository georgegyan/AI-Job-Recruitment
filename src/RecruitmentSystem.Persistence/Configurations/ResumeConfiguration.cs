using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Persistence.Configurations;

public class ResumeConfiguration
    : IEntityTypeConfiguration<Resume>
{
    public void Configure(
        EntityTypeBuilder<Resume> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(r => r.FilePath)
            .HasMaxLength(500)
            .IsRequired();

        builder.HasOne(r => r.Candidate)
            .WithMany(u => u.Resumes)
            .HasForeignKey(r => r.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}