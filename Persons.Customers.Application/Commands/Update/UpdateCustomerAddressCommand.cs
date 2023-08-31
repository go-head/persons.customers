using GoHead.Domain;
using MediatR;
using Persons.Customers.Application.Commands.Create;

namespace Persons.Customers.Application.Commands.Update;

public record UpdateCustomerAddressCommand() : IRequest<Result<Exception, Unity>>
{
    public string? Zipcode { get; set; }
    public string? AddressLine { get; set; }
    public string? BuildingNumber { get; set; }
    public string? Neighborhood { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }

    internal string? DocumentNumber { get; set; }

    public void SetDocumentNumber(string documentNumber)
    {
        DocumentNumber = documentNumber;
    }
}