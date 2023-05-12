using ProjectManagement.Shared.Primitives.BaseEntity;

namespace Projects.Core.Entities;

public class ProjectDescription : BaseEntity
{
    public DateTime StartDate { get; }
    public DateTime EndDate { get; private set; }
    public Guid PriorityId { get; private set; }
    public Priority Priority { get; }
    public Guid ManagerId { get; private set; }
    public Manager Manager { get; }
    public Guid ExecutorId { get; private set; }
    public Executor Executor { get; }

    private ProjectDescription(
        DateTime startDate,
        DateTime endDate,
        Guid priorityId,
        Guid managerId,
        Guid executorId
    )
        : base()
    {
        StartDate = startDate;
        EndDate = endDate;
        PriorityId = priorityId;
        ManagerId = managerId;
        ExecutorId = executorId;
    }

    public static ProjectDescription Init(
        DateTime startDate,
        DateTime endDate,
        Guid priorityId,
        Guid managerId,
        Guid executorId
    )
    {
        return new ProjectDescription(startDate, endDate, priorityId, managerId, executorId);
    }

    public static ProjectDescription UpdateEndDate(
        ProjectDescription projectDescription,
        DateTime endDate
    )
    {
        projectDescription.EndDate = endDate;

        return projectDescription;
    }

    public static ProjectDescription UpdatePriorityId(
        ProjectDescription projectDescription,
        Guid priorityId
    )
    {
        projectDescription.PriorityId = priorityId;

        return projectDescription;
    }

    public static ProjectDescription UpdateManagerId(
        ProjectDescription projectDescription,
        Guid managerId
    )
    {
        projectDescription.ManagerId = managerId;

        return projectDescription;
    }

    public static ProjectDescription UpdateExecutorId(
        ProjectDescription projectDescription,
        Guid executorId
    )
    {
        projectDescription.ExecutorId = executorId;

        return projectDescription;
    }
}
