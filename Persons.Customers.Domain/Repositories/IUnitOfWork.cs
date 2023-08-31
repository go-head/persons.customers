using GoHead.Domain;

namespace Persons.Customers.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<Result<Exception, bool>> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}