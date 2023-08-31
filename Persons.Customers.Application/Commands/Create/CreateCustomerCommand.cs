using GoHead.Domain;
using MediatR;

namespace Persons.Customers.Application.Commands.Create;

public record CreateCustomerCommand : IRequest<Result<Exception, Unity>>
{
    public string DocumentNumber { get; set; } = string.Empty;
    public string RegisterName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public DateTime? BirthDate { get; set; }

    public CustomerAddress Address { get; set; } = new();
}

public record CustomerAddress
{
    public string? Zipcode { get; set; }
    public string? AddressLine { get; set; }
    public string? BuildingNumber { get; set; }
    public string? Neighborhood { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
}