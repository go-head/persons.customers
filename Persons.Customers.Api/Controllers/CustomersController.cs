using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persons.Customers.Application.Commands.Create;
using Persons.Customers.Application.Commands.Update;
using Persons.Customers.Application.Queries;

namespace Persons.Customers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ApiControllerBase<CustomersController>
    {
        private readonly IMediator mediator;

        public CustomersController(
            ILogger<CustomersController> logger,
            IMediator mediator) : base(logger)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Post([FromBody] CreateCustomerCommand customerCreate)
        {
            _logger.LogDebug("Initialize customer creation", customerCreate);

            return HandleCommand(await mediator.Send(customerCreate));
        }

        [HttpGet("{documentNumber}")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Get(string documentNumber)
        {
            _logger.LogDebug("Initialize customer retrieval", documentNumber);

            var result = await mediator.Send(new CustomerGetByDocNumberCommand(documentNumber));

            return Ok(result.Success);
        }

        [HttpPatch("{documentNumber}")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> Patch(
            string documentNumber,
            [FromBody] UpdateCustomerCommand customerUpdate)
        {
            _logger.LogDebug("Initialize customer creation", customerUpdate);
            customerUpdate.SetDocumentNumber(documentNumber);
            return HandleCommand(await mediator.Send(customerUpdate));
        }

        [HttpPatch("{documentNumber}/Address")]
        [ProducesResponseType(statusCode: 200)]
        [ProducesResponseType(statusCode: 400)]
        [ProducesResponseType(statusCode: 404)]
        public async Task<IActionResult> PatchAddress(
            string documentNumber,
            [FromBody] UpdateCustomerAddressCommand updateAddress)
        {
            _logger.LogDebug("Initialize customer creation", updateAddress);

            updateAddress.SetDocumentNumber(documentNumber);
            return HandleCommand(await mediator.Send(updateAddress));
        }
    }
}