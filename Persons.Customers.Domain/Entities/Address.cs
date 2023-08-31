using Persons.Customers.Domain.Abstractions;

namespace Persons.Customers.Domain.Entities
{
    public class Address : Entity
    {
        public Address()
        { }

        public Address(string? zipcode, string? addressLine, string? buildingNumber, string? neighborhood, string? country, string? state, string? city)
        {
            Zipcode = zipcode;
            AddressLine = addressLine;
            BuildingNumber = buildingNumber;
            Neighborhood = neighborhood;
            Country = country;
            State = state;
            City = city;
        }

        public string? Zipcode { get; private set; }
        public string? AddressLine { get; private set; }
        public string? BuildingNumber { get; private set; }
        public string? Neighborhood { get; private set; }
        public string? Country { get; private set; }
        public string? State { get; private set; }
        public string? City { get; private set; }

        internal void Update(string? addressLine, string? zipcode, string? buildingNumber, string? neighborhood, string? city, string? country, string? state)
        {
            Zipcode = zipcode;
            AddressLine = addressLine;
            BuildingNumber = buildingNumber;
            Neighborhood = neighborhood;
            Country = country;
            State = state;
            City = city;
        }
    }
}