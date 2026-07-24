using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Persistence.Configurations;

public class ResumeAnalysisConfiguration
    : IEntityTypeConfiguration<ResumeAnalysis>
{
    public void Configure(
        EntityTypeBuilder<ResumeAnalysis> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Resume)
            .WithOne(x => x.Analysis)
            .HasForeignKey<ResumeAnalysis>(
                x => x.ResumeId);

        builder.Property(x => x.Skills)
            .HasMaxLength(4000);

        builder.Property(x => x.Education)
            .HasMaxLength(4000);

        builder.Property(x => x.Experience)
            .HasMaxLength(4000);

        builder.Property(x => x.Recommendation)
            .HasMaxLength(2000);
    }
}