using GoHead.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Persons.Customers.Api.Controllers
{
    [ApiController]
    public class ApiControllerBase<TSourceBase> : ControllerBase
    {
        protected readonly ILogger<TSourceBase> _logger;

        public ApiControllerBase(ILogger<TSourceBase> logger)
        {
            _logger = logger;
        }

        protected IActionResult HandleCommand<TFailure, TSuccess>
            (Result<TFailure, TSuccess> result) where TFailure : Exception
        {
            if (result.IsSuccess) _logger.LogDebug("Finished");
            return result.IsSuccess ? Ok(result.Success) : throw result.Failure;
        }

        protected IActionResult HandleQuery<TSource, TSuccess>(Result<Exception, TSource> result)
        {
            return result.IsSuccess ? Ok(result.Success) : throw result.Failure;
        }
    }
}