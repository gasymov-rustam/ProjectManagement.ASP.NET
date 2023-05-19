using Microsoft.EntityFrameworkCore;
using Projects.Core.Entities;

namespace Projects.Infrastructure;

public class ProjectManagementContext : DbContext
{
    public DbSet<Employee> Employees { get; set; } = default!;
    public DbSet<Executor> Executors { get; set; } = default!;
    public DbSet<Manager> Managers { get; set; } = default!;
    public DbSet<Priority> Priorities { get; set; } = default!;
    public DbSet<Project> Projects { get; set; } = default!;
    public DbSet<ProjectDescription> ProjectDescriptions { get; set; } = default!;
    public DbSet<ProjectEmployee> ProjectEmployees { get; set; } = default!;
    public DbSet<Role> Roles { get; set; } = default!;

    public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectManagementContext).Assembly);
    }
}
