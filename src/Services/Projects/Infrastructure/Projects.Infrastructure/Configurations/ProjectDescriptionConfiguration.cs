using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projects.Core.Entities;

namespace Projects.Infrastructure.Configurations;

public class ProjectDescriptionConfiguration : IEntityTypeConfiguration<ProjectDescription>
{
    public void Configure(EntityTypeBuilder<ProjectDescription> builder)
    {
        builder.HasKey(e => e.Gid);
        builder.Property(e => e.EndDate).IsRequired();
        builder.Property(e => e.StartDate).IsRequired();
    }
}
