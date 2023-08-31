namespace Persons.Customers.Domain.Interfaces;

public interface IEntityDomain : IEntity
{
    IReadOnlyCollection<INotificationEventDomain> DomainEvents { get; }

    void AddDomainEvent(INotificationEventDomain eventItem);

    void ClearDomainEvents();
}