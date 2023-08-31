using Persons.Customers.Domain.Entities;
using Persons.Customers.Domain.Interfaces;

namespace Persons.Customers.Domain.Events
{
    public class CustomerDeleteEventDomain : INotificationEventDomain
    {
        public string RoutingKey => "customer.command.delete";
        private readonly Customer customer;

        public CustomerDeleteEventDomain(Customer customer)
        {
            this.customer = customer;
        }

        public Customer Customer => customer;
    }
}