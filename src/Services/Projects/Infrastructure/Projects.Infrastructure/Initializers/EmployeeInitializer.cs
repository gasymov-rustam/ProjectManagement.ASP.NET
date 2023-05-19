using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projects.Core.Entities;

namespace Projects.Infrastructure.Initializers;

public class EmployeeInitializer : IDataInitializer
{
    private readonly ProjectManagementContext _dbContext;
    private readonly ILogger<EmployeeInitializer> _logger;

    public EmployeeInitializer(
        ProjectManagementContext dbContext,
        ILogger<EmployeeInitializer> logger
    )
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task InitAsync()
    {
        if (_dbContext.Roles.Any())
            return;

        await AddEmployeesAsync();

        await _dbContext.SaveChangesAsync();
    }

    private async Task AddEmployeesAsync()
    {
        var role = await _dbContext.Roles.FirstOrDefaultAsync();

        await _dbContext.Employees.AddAsync(
            Employee.Init("Alex", "Alexandrov", "alex@i.ua", role.Gid)
        );

        _logger.LogInformation("Initialized employees");
    }
}
