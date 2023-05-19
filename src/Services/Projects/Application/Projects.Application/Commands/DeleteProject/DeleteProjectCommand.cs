using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Projects.Application.Abstractions;
using Projects.Infrastructure;

namespace Projects.Application.Commands.DeleteProject;

public record DeleteProjectCommand(Guid ProjectId) : ICommand<Guid>;

public class DeleteProjectHandler
    : BaseCommandHandler<DeleteProjectCommand, Guid, DeleteProjectHandler>
{
    public DeleteProjectHandler(
        ProjectManagementContext context,
        ILogger<DeleteProjectHandler> logger
    )
        : base(context, logger) { }

    public async override ValueTask<Guid> Handle(
        DeleteProjectCommand command,
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

        _context.Projects.Remove(project);

        await _context.SaveChangesAsync(cancellationToken);

        return project.Gid;
    }
}
