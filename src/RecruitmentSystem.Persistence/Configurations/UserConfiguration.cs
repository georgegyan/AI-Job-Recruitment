using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecruitmentSystem.Domain.Entities;

namespace RecruitmentSystem.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);


        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);


        builder.Property(x => x.PasswordHash)
            .IsRequired();


        builder.HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);
    }
}