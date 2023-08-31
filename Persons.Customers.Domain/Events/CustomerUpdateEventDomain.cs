using Persons.Customers.Domain.Entities;
using Persons.Customers.Domain.Interfaces;

namespace Persons.Customers.Domain.Events
{
    public class CustomerUpdateEventDomain : INotificationEventDomain
    {
        public string RoutingKey => "customer.command.update";
        private readonly Customer customer;

        public CustomerUpdateEventDomain(Customer customer)
        {
            this.customer = customer;
        }

        public Customer Customer => customer;
    }
}