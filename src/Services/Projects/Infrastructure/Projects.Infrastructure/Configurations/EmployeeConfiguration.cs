using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projects.Core.Entities;
using Projects.Core.ValueObjects;

namespace Projects.Infrastructure.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Gid);
        builder
            .Property(e => e.Email)
            .HasConversion(x => x!.Value, x => Email.Init(x))
            .HasMaxLength(50);
        builder.Property(e => e.Name).HasMaxLength(50);
        builder.Property(e => e.Surname).HasMaxLength(50);

        builder
            .HasOne(e => e.Role)
            .WithMany(r => r.Employees)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(e => e.Projects)
            .WithMany(p => p.Employees)
            .UsingEntity<Dictionary<string, object>>(
                "ProjectEmployee",
                e => e.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
                p => p.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId"),
                e =>
                {
                    e.Property<string>("Gid");
                    e.HasKey("Gid");
                }
            );
    }
}
