using GoHead.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persons.Customers.Domain.Entities;
using Persons.Customers.Domain.Repositories;

namespace Persons.Customers.Application.Commands.Create;

public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Result<Exception, Unity>>
{
    private readonly ILogger<CreateCustomerHandler> log;
    private readonly ICustomerRepository customerRepository;

    public CreateCustomerHandler(
        ILogger<CreateCustomerHandler> logger,
        ICustomerRepository customerRepository)
    {
        log = logger;
        this.customerRepository = customerRepository;
    }

    public async Task<Result<Exception, Unity>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        log.LogInformation("Handler - Starting customer processing");

        var exists = await customerRepository.ExistsAsync(request.DocumentNumber);
        if (exists)
            return new Exception("Already exists - 409");

        var customer = Customer.Create(request.DocumentNumber, request.RegisterName);
        customer.BirthDate = request.BirthDate;
        customer.Email = request.Email;
        customer.SetActiveStatus();
        customer.SetAddress(
            request.Address.Zipcode,
            request.Address.AddressLine,
            request.Address.Neighborhood,
            request.Address.BuildingNumber,
            request.Address.City,
            request.Address.Country,
            request.Address.State);

        var result = await customerRepository.AddCustomerAsync(customer);

        if (result.IsFailure) return new Exception();

        await customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return Unity.Successful;
    }
}