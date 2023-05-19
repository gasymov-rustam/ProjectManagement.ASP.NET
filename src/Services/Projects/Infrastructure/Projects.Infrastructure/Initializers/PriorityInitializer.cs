using Microsoft.Extensions.Logging;
using Projects.Core.Entities;

namespace Projects.Infrastructure.Initializers;

public class PriorityInitializer : IDataInitializer
{
    private readonly ProjectManagementContext _dbContext;
    private readonly ILogger<PriorityInitializer> _logger;

    public PriorityInitializer(
        ProjectManagementContext dbContext,
        ILogger<PriorityInitializer> logger
    )
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InitAsync()
    {
        if (_dbContext.Roles.Any())
            return;

        await AddPrioritiesAsync();

        await _dbContext.SaveChangesAsync();
    }

    private async Task AddPrioritiesAsync()
    {
        await _dbContext.Priorities.AddAsync(Priority.Init("High"));
        await _dbContext.Priorities.AddAsync(Priority.Init("Medium"));
        await _dbContext.Priorities.AddAsync(Priority.Init("Low"));

        _logger.LogInformation("Initialized priorities");
    }
}
