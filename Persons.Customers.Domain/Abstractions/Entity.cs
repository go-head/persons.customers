using Newtonsoft.Json;
using Persons.Customers.Domain.Interfaces;

namespace Persons.Customers.Domain.Abstractions
{
    public abstract class Entity : IEntity, IEquatable<Entity>
    {
        protected Entity()
        { }

        public Guid Id { get; private init; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public bool IsTransient()
        {
            return Id == default;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || IsTransient())
                return false;
            else
                return item.Id == Id;
        }

        public bool Equals(Entity? other)
        {
            if (other is null) return false;
            if (other.GetType() != GetType()) return false;

            return other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Equals(left, null))
                return Equals(right, null) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}