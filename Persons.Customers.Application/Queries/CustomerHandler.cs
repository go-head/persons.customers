using GoHead.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persons.Customers.Application.Commands.Create;
using Persons.Customers.Domain.Entities;
using Persons.Customers.Domain.Repositories;

namespace Persons.Customers.Application.Queries
{
    public class CustomerHandler :
        IRequestHandler<CustomerGetAllCommand, Result<Exception, IEnumerable<Customer>>>,
        IRequestHandler<CustomerGetByDocNumberCommand, Result<Exception, IEnumerable<Customer>>>

    {
        private readonly ILogger<CreateCustomerHandler> log;
        private readonly ICustomerRepository customerRepository;

        public CustomerHandler(
            ILogger<CreateCustomerHandler> logger,
            ICustomerRepository customerRepository)
        {
            log = logger;
            this.customerRepository = customerRepository;
        }

        public async Task<Result<Exception, IEnumerable<Customer>>> Handle(CustomerGetAllCommand request, CancellationToken cancellationToken)
        {
            log.LogInformation("");

            return Result.Run(() => customerRepository.Get(includeProperties: $"{nameof(Customer.Document)},{nameof(Customer.Status)}"));
        }

        public async Task<Result<Exception, IEnumerable<Customer>>> Handle(CustomerGetByDocNumberCommand request, CancellationToken cancellationToken)
        {
            log.LogInformation("");

            return Result.Run(() => customerRepository.Get(
                x => x.DocumentNumber == request.DocumentNumber,
                includeProperties: $"{nameof(Customer.Document)},{nameof(Customer.Document)}.{nameof(Customer.Document.DocumentType)},{nameof(Customer.Status)}"));
        }
    }
}