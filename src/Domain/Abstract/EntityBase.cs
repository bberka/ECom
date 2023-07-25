namespace ECom.Domain.Abstract;

public abstract class EntityBase : IEntity, IEquatable<EntityBase>
{
    public Guid Guid { get; set; }

    public bool Equals(EntityBase? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        if (other?.Guid == Guid) return true;
        return false;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((EntityBase)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Guid);
    }
}