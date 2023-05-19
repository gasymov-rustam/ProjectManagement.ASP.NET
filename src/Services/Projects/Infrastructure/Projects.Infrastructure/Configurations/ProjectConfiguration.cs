using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projects.Core.Entities;

namespace Projects.Infrastructure.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(e => e.Gid);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
        builder.Property(e => e.CustomerCompany).IsRequired().HasMaxLength(50);
        builder.Property(e => e.ContactorCompany).IsRequired().HasMaxLength(50);
        builder
            .HasMany(e => e.Employees)
            .WithMany(p => p.Projects)
            .UsingEntity<Dictionary<string, object>>(
                "ProjectEmployee",
                e => e.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId"),
                p => p.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
                e =>
                {
                    e.Property<string>("Gid");
                    e.HasKey("Gid");
                }
            );
    }
}
