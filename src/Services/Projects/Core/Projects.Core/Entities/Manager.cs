using ProjectManagement.Shared.Primitives.BaseEntity;

namespace Projects.Core.Entities;

public class Manager : BaseEntity
{
    public Guid EmployeeId { get; private set; }
    public Employee Employee { get; }

    private Manager(Guid employeeId)
        : base()
    {
        EmployeeId = employeeId;
    }

    public static Manager Init(Guid employeeId)
    {
        return new Manager(employeeId);
    }

    public static Manager UpdateEmployeeId(Manager manager, Guid employeeId)
    {
        manager.EmployeeId = employeeId;

        return manager;
    }
}
