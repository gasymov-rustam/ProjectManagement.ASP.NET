using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projects.Core.Entities;

namespace Projects.Infrastructure.Initializers;

public class RoleInitializer : IDataInitializer
{
    private readonly ProjectManagementContext _dbContext;
    private readonly ILogger<RoleInitializer> _logger;

    public RoleInitializer(ProjectManagementContext dbContext, ILogger<RoleInitializer> logger)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InitAsync()
    {
        if (_dbContext.Roles.Any())
            return;

        await AddRolesAsync();

        await _dbContext.SaveChangesAsync();
    }

    private async Task AddRolesAsync()
    {
        await _dbContext.Roles.AddAsync(Role.Init("Employee"));
        await _dbContext.Roles.AddAsync(Role.Init("Manager"));
        await _dbContext.Roles.AddAsync(Role.Init("Executor"));

        _logger.LogInformation("Initialized roles");
    }
}
