using Persons.Customers.Domain.Abstractions;
using Persons.Customers.Domain.Enums;
using Persons.Customers.Domain.Events;
using Persons.Customers.Domain.Extensions;

namespace Persons.Customers.Domain.Entities
{
    public class Customer : AggregateRoot
    {
        public Customer()
        { }

        public static Customer Create(string documentNumber, string registerName)
        {
            var customer = new Customer
            {
                RegisterName = registerName,
                DocumentNumber = documentNumber
            };
            customer.SetDocumentNumber(documentNumber);

            customer.AddDomainEvent(new CustomerCreateEventDomain(customer));

            return customer;
        }

        public string DocumentNumber { get; set; } = string.Empty;
        public string RegisterName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }

        public CustomerDocument Document { get; private set; }

        public Address? Address { get; private set; }

        private int _statusId;
        public CustomerStatusTypeEnum Status { get; private set; }

        public void SetActiveStatus()
        {
            _statusId = CustomerStatusTypeEnum.ACTIVE.Id;
        }

        public void SetBlockedStatus()
        {
            _statusId = CustomerStatusTypeEnum.BLOCKED.Id;
        }

        public void SetCanceledStatus()
        {
            _statusId = CustomerStatusTypeEnum.CANCELED.Id;
        }

        public void SetAddress(string? zipcode, string? addressLine, string? neighborhood, string? buildingNumber, string? city, string? country, string? state)
        {
            Address = new Address(
                zipcode: zipcode,
                addressLine: addressLine,
                buildingNumber: buildingNumber,
                neighborhood: neighborhood,
                city: city,
                country: country,
                state: state);
        }

        public void UpdateAddress(string? zipcode, string? addressLine, string? neighborhood, string? buildingNumber, string? city, string? country, string? state)
        {
            this.Address?.Update(zipcode, addressLine, buildingNumber, neighborhood, city, country, state);
        }

        private void SetDocumentNumber(string documentNumber)
        {
            Document = new CustomerDocument(DocumentTypeEnum.CPF, documentNumber);
            DocumentNumber = documentNumber;
        }
    }
}