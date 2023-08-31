using GoHead.Domain;
using MediatR;
using Persons.Customers.Application.Commands.Create;

namespace Persons.Customers.Application.Commands.Update;

public record UpdateCustomerCommand(
    string? RegisterName,
    string? Email,
    DateTime? BirthDate) : IRequest<Result<Exception, Unity>>
{
    internal string? DocumentNumber { get; set; }
    public void SetDocumentNumber(string? documentNumber)
    {
        DocumentNumber = documentNumber;
    }
}