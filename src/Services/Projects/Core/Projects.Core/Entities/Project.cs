using ProjectManagement.Shared.Primitives.BaseEntity;

namespace Projects.Core.Entities;

public class Project : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string CustomerCompany { get; private set; } = string.Empty;
    public string ContactorCompany { get; private set; } = string.Empty;
    private readonly List<Employee> _employees = new();
    public IReadOnlyCollection<Employee> Employees => _employees;

    private Project(string name, string customerCompany, string contactorCompany)
        : base()
    {
        Name = name;
        CustomerCompany = customerCompany;
        ContactorCompany = contactorCompany;
    }

    public static Project Init(string name, string customerCompany, string contactorCompany)
    {
        return new Project(name, customerCompany, contactorCompany);
    }

    public static Project UpdateName(Project project, string name)
    {
        project.Name = name;

        return project;
    }

    public static Project UpdateCustomerCompany(Project project, string customerCompany)
    {
        project.CustomerCompany = customerCompany;

        return project;
    }

    public static Project UpdateContactorCompany(Project project, string contactorCompany)
    {
        project.ContactorCompany = contactorCompany;

        return project;
    }

    public static Project GeneralUpdate(
        Project project,
        string name,
        string customerCompany,
        string contactorCompany
    )
    {
        if (name is not null && name != project.Name)
        {
            project.Name = name;
        }

        if (customerCompany is not null && customerCompany != project.CustomerCompany)
        {
            project.CustomerCompany = customerCompany;
        }

        if (contactorCompany is not null && contactorCompany != project.ContactorCompany)
        {
            project.ContactorCompany = contactorCompany;
        }

        return project;
    }
}
