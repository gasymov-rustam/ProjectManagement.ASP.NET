using ProjectManagement.Shared.Primitives.BaseEntity;

namespace Projects.Core.Entities;

public class Priority : BaseEntity
{
    public string Name { get; private set; } = string.Empty;

    private Priority(string name)
        : base()
    {
        Name = name;
    }

    public static Priority Init(string name)
    {
        return new Priority(name);
    }

    public static Priority UpdateName(Priority priority, string name)
    {
        priority.Name = name;
        return priority;
    }
}
