namespace ProjectManagement.Shared.Primitives.BaseEntity;

public interface IAuditableEntity
{
    DateTimeOffset CreatedAt { get; set; }
    DateTimeOffset? LastModified { get; set; }
}
