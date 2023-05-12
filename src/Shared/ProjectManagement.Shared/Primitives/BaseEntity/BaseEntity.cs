namespace ProjectManagement.Shared.Primitives.BaseEntity;

public abstract class BaseEntity : IEquatable<BaseEntity>, IAuditableEntity
{
    public Guid Gid { get; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? LastModified { get; set; }

    public BaseEntity()
    {
        Gid = Guid.NewGuid();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;

        if (obj is not BaseEntity entity)
            return false;

        return entity.Gid == Gid;
    }

    public bool Equals(BaseEntity? other)
    {
        if (other is null)
            return false;

        if (other.GetType() != GetType())
            return false;

        return other.Gid == Gid;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode() * 41;
    }
}
