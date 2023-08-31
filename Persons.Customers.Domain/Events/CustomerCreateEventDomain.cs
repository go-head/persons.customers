using Persons.Customers.Domain.Entities;
using Persons.Customers.Domain.Interfaces;

namespace Persons.Customers.Domain.Events
{
    public class CustomerCreateEventDomain : INotificationEventDomain
    {
        public string RoutingKey => "customer.command.create";
        private readonly Customer customer;

        public CustomerCreateEventDomain(Customer customer)
        {
            this.customer = customer;
        }

        public Customer Customer => customer;
    }
}