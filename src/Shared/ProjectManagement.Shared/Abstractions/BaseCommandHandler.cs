namespace Projects.Application.Abstractions;

public class BaseCommandHandler
{
    protected readonly ITrackerDBContext _context;
    protected readonly ILogger<TCommand> _logger;
    protected readonly ICacheService _cacheService;

    public BaseCommandHandler(
        ITrackerDBContext context,
        ILogger<TCommand> logger,
        ICacheService cacheService
    )
    {
        _context = context;
        _logger = logger;
        _cacheService = cacheService;
    }

    public abstract ValueTask<TResult> Handle(
        TCommand command,
        CancellationToken cancellationToken
    );
}
