using Mediator;
using Microsoft.Extensions.Logging;
using Projects.Application.Abstractions;
using Projects.Core.Entities;
using Projects.Core.ValueObjects;
using Projects.Infrastructure;

namespace Projects.Application.Commands.CreateProject;

public record EmployeeDto(string Name, string Surname, string Email, Guid RoleId);

public record CreateProjectCommand(
    string Name,
    string CustomerCompany,
    string ContactorCompany,
    List<EmployeeDto> Employees
) : ICommand<Guid>;

public class CreateProjectHandler
    : BaseCommandHandler<CreateProjectCommand, Guid, CreateProjectHandler>
{
    public CreateProjectHandler(
        ProjectManagementContext context,
        ILogger<CreateProjectHandler> logger
    )
        : base(context, logger) { }

    public async override ValueTask<Guid> Handle(
        CreateProjectCommand command,
        CancellationToken cancellationToken
    )
    {
        var project = Project.Init(command.Name, command.CustomerCompany, command.ContactorCompany);

        var createdProject = await _context.Projects.AddAsync(project, cancellationToken);

        await _context.Employees.AddRangeAsync(
            command.Employees.Select(
                e => Employee.Init(e.Name, e.Surname, Email.Init(e.Email), e.RoleId)
            ),
            cancellationToken
        );

        if (createdProject is null)
        {
            _logger.LogError("Project not created");
            return Guid.Empty;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return createdProject.Entity.Gid;
    }
}
