using GoHead.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using Persons.Customers.Application.Commands.Create;
using Persons.Customers.Domain.Repositories;
using System.Net;

namespace Persons.Customers.Application.Commands.Update;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Result<Exception, Unity>>
{
    private readonly ILogger<UpdateCustomerHandler> log;
    private readonly ICustomerRepository customerRepository;

    public UpdateCustomerHandler(
        ILogger<UpdateCustomerHandler> logger,
        ICustomerRepository customerRepository)
    {
        this.log = logger;
        this.customerRepository = customerRepository;
    }

    public async Task<Result<Exception, Unity>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        if (request.DocumentNumber is null)
            return new ArgumentNullException(nameof(request.DocumentNumber));

        var customerDb = await customerRepository.GetByDocumentNumberAsync(request.DocumentNumber);
        if (customerDb is null)
            return new Exception("Does not exist - 409");

        if (request.RegisterName is not null)
            customerDb.RegisterName = request.RegisterName;

        if (request.Email is not null)
            customerDb.Email = request.Email;

        if (request.BirthDate is not null)
            customerDb.BirthDate = request.BirthDate;

        await customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return Unity.Successful;
    }
}