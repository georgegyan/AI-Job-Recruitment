using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitmentSystem.Domain.Entities;
using DomainApplication = RecruitmentSystem.Domain.Entities.Application;

namespace RecruitmentSystem.Persistence.Configurations;

public class ApplicationConfiguration
    : IEntityTypeConfiguration<DomainApplication>
{
    public void Configure(
        EntityTypeBuilder<DomainApplication> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Status)
            .HasMaxLength(50);

        builder.HasOne(a => a.Candidate)
            .WithMany(u => u.Applications)
            .HasForeignKey(a => a.CandidateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Job)
            .WithMany(j => j.Applications)
            .HasForeignKey(a => a.JobId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}