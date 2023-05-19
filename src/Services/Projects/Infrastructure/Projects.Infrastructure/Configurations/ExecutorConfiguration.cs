using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projects.Core.Entities;

namespace Projects.Infrastructure.Configurations;

public class ExecutorConfiguration : IEntityTypeConfiguration<Executor>
{
    public void Configure(EntityTypeBuilder<Executor> builder)
    {
        builder.HasKey(e => e.Gid);
    }
}
