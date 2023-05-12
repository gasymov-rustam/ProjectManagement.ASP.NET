using ProjectManagement.Shared.Primitives.BaseEntity;

namespace Projects.Core.Entities;

public class Executor : BaseEntity
{
    public Guid EmployeeId { get; private set; }
    public Employee Employee { get; }

    private Executor(Guid employeeId)
        : base()
    {
        EmployeeId = employeeId;
    }

    public static Executor Init(Guid employeeId)
    {
        return new Executor(employeeId);
    }

    public static Executor UpdateEmployeeId(Executor executor, Guid employeeId)
    {
        executor.EmployeeId = employeeId;

        return executor;
    }
}
