using Mediator;
using Microsoft.Extensions.Logging;
using Projects.Infrastructure;

namespace Projects.Application.Abstractions;

public abstract class BaseCommandHandler<TCommand, TResult, ClassName>
    : ICommandHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
    protected readonly ProjectManagementContext _context;
    protected readonly ILogger<ClassName> _logger;

    public BaseCommandHandler(ProjectManagementContext context, ILogger<ClassName> logger)
    {
        _context = context;
        _logger = logger;
    }

    public abstract ValueTask<TResult> Handle(
        TCommand command,
        CancellationToken cancellationToken
    );
}
