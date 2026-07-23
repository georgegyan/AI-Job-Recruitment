using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired();

        builder.Property(c => c.Description)
            .IsRequired();

        builder.Property(c => c.Website)
            .IsRequired();

        builder.HasOne(c => c.Recruiter)
            .WithMany()
            .HasForeignKey(c => c.RecruiterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}