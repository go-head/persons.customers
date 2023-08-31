using MediatR;
using Persons.Customers.Domain.Events;

namespace Persons.Customers.Application.Events
{
    public class CustomerEventHandler :
        INotificationHandler<CustomerCreateEventDomain>,
        INotificationHandler<CustomerUpdateEventDomain>,
        INotificationHandler<CustomerDeleteEventDomain>
    {
        public Task Handle(CustomerCreateEventDomain notification, CancellationToken cancellationToken)
        {
            var not = notification as CustomerCreateEventDomain;

            return Task.CompletedTask;
        }

        public Task Handle(CustomerDeleteEventDomain notification, CancellationToken cancellationToken)
        {
            var not = notification as CustomerDeleteEventDomain;

            return Task.CompletedTask;
        }

        public Task Handle(CustomerUpdateEventDomain notification, CancellationToken cancellationToken)
        {
            var not = notification as CustomerUpdateEventDomain;

            return Task.CompletedTask;
        }
    }
}