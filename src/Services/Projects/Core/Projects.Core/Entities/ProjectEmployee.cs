using ProjectManagement.Shared.Primitives.BaseEntity;

namespace Projects.Core.Entities;

public class ProjectEmployee : BaseEntity
{
    public Guid ProjectId { get; private set; }
    public Project Project { get; }
    public Guid EmployeeId { get; private set; }
    public Employee Employee { get; }

    private ProjectEmployee(Guid projectId, Guid employeeId)
        : base()
    {
        ProjectId = projectId;
        EmployeeId = employeeId;
    }

    public static ProjectEmployee Init(Guid projectId, Guid employeeId)
    {
        return new ProjectEmployee(projectId, employeeId);
    }

    public static ProjectEmployee UpdateProjectId(ProjectEmployee projectEmployee, Guid projectId)
    {
        projectEmployee.ProjectId = projectId;

        return projectEmployee;
    }

    public static ProjectEmployee UpdateEmployeeId(ProjectEmployee projectEmployee, Guid employeeId)
    {
        projectEmployee.EmployeeId = employeeId;

        return projectEmployee;
    }
}
