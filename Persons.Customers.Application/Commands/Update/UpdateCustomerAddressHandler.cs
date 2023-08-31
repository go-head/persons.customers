using GoHead.Domain;
using MediatR;

namespace Persons.Customers.Application.Commands.Update;

public class UpdateCustomerAddressHandler : IRequestHandler<UpdateCustomerAddressCommand, Result<Exception, Unity>>
{
    public async Task<Result<Exception, Unity>> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}