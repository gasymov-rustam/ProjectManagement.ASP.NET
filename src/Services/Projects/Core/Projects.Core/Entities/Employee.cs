using ProjectManagement.Shared.Primitives.BaseEntity;
using Projects.Core.ValueObjects;

namespace Projects.Core.Entities;

public class Employee : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Surname { get; private set; } = string.Empty;
    public Email Email { get; private set; } = string.Empty;
    public Guid RoleId { get; private set; }
    public Role Role { get; }
    private readonly List<Project> _projects = new();
    public IReadOnlyCollection<Project> Projects => _projects;

    private Employee(string name, string surname, Email email, Guid roleId)
        : base()
    {
        Name = name;
        Surname = surname;
        Email = email;
        RoleId = roleId;
    }

    public static Employee Init(string name, string surname, Email email, Guid roleId)
    {
        return new Employee(name, surname, email, roleId);
    }

    public static Employee UpdateName(Employee employee, string name)
    {
        employee.Name = name;

        return employee;
    }

    public static Employee UpdateSurname(Employee employee, string surname)
    {
        employee.Surname = surname;

        return employee;
    }

    public static Employee UpdateEmail(Employee employee, string emailRequest)
    {
        employee.Email = Email.Init(emailRequest);

        return employee;
    }

    public static Employee UpdateRoleId(Employee employee, Guid roleId)
    {
        employee.RoleId = roleId;

        return employee;
    }
}
