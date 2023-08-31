using GoHead.Domain;
using MediatR;
using Persons.Customers.Domain.Entities;

namespace Persons.Customers.Application.Queries
{
    public class CustomerGetAllCommand : IRequest<Result<Exception, IEnumerable<Customer>>>
    {
    }
}