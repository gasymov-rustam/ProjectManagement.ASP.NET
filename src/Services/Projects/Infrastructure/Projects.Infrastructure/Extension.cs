using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projects.Infrastructure;
using Projects.Infrastructure.Initializers;

namespace Tracker.Infrastructure;

public static class Extension
{
    public static IServiceCollection AddDataBaseContext(
        this IServiceCollection services,
        string connectionString
    )
    {
        services.AddDbContext<ProjectManagementContext>(
            options =>
                options.UseNpgsql(
                    connectionString,
                    b => b.MigrationsAssembly("ProjectManagement.Api")
                )
        );

        services.AddHostedService<DatabaseInitializer<ProjectManagementContext>>();
        services.AddHostedService<DataInitializer>();
        services.AddInitializer<RoleInitializer>();
        services.AddInitializer<PriorityInitializer>();
        services.AddInitializer<EmployeeInitializer>();
        // services.AddTransient<IDataInitializer, RoleInitializer>();

        return services;
    }

    public static IServiceCollection AddInitializer<T>(this IServiceCollection services)
        where T : class, IDataInitializer => services.AddTransient<IDataInitializer, T>();
}
