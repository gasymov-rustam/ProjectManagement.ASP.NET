using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projects.Application.Abstractions;
using Projects.Core.Entities;
using Projects.Infrastructure;

namespace Projects.Application.Commands.UpdateProject;

public record UpdateProjectCommand(
    Guid ProjectId,
    string Name,
    string CustomerCompany,
    string ContactorCompany
) : ICommand<Guid>;

public class UpdateHandlerHandler
    : BaseCommandHandler<UpdateProjectCommand, Guid, UpdateHandlerHandler>
{
    public UpdateHandlerHandler(
        ProjectManagementContext context,
        ILogger<UpdateHandlerHandler> logger
    )
        : base(context, logger) { }

    public async override ValueTask<Guid> Handle(
        UpdateProjectCommand command,
        CancellationToken cancellationToken
    )
    {
        var project = await _context.Projects.FirstOrDefaultAsync(
            x => x.Gid == command.ProjectId,
            cancellationToken
        );

        if (project is null)
        {
            _logger.LogError("Project not found");
            return Guid.Empty;
        }

        Project.GeneralUpdate(
            project,
            command.Name,
            command.CustomerCompany,
            command.ContactorCompany
        );

        await _context.SaveChangesAsync(cancellationToken);

        return project.Gid;
    }
}
