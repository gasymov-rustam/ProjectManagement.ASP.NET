using ProjectManagement.Shared.Primitives.BaseEntity;

namespace Projects.Core.Entities;

public class Role : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    private readonly List<Employee> _employees = new();

    private Role(string name)
        : base()
    {
        Name = name;
    }

    public IReadOnlyCollection<Employee> Employees => _employees;

    public static Role Init(string name)
    {
        return new Role(name);
    }

    public static Role UpdateName(Role role, string name)
    {
        role.Name = name;

        return role;
    }
}
