using Mediator;
using Microsoft.Extensions.Logging;
using Projects.Infrastructure;

namespace Projects.Application.Abstractions;

public abstract class BaseQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    protected readonly ProjectManagementContext _context;
    protected readonly ILogger<TQuery> _logger;

    public BaseQueryHandler(ProjectManagementContext context, ILogger<TQuery> logger)
    {
        _context = context;
        _logger = logger;
    }

    public abstract ValueTask<TResult> Handle(TQuery command, CancellationToken cancellationToken);
}
