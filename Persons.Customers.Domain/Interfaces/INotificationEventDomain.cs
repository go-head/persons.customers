using MediatR;

namespace Persons.Customers.Domain.Interfaces
{
    public interface INotificationEventDomain : INotification
    {
        string RoutingKey { get; }
    }
}