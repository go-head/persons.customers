using Newtonsoft.Json;
using Persons.Customers.Domain.Interfaces;

namespace Persons.Customers.Domain.Abstractions
{
    public abstract class AggregateRoot : Entity, IEntityDomain
    {
        public AggregateRoot()
        { }

        private List<INotificationEventDomain> _domainEvents = new();

        [JsonIgnore]
        public IReadOnlyCollection<INotificationEventDomain> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotificationEventDomain eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}