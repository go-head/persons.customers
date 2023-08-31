using GoHead.Domain;
using MediatR;
using Persons.Customers.Domain.Entities;

namespace Persons.Customers.Application.Queries;

public record CustomerGetByDocNumberCommand(string DocumentNumber) : IRequest<Result<Exception, IEnumerable<Customer>>>;