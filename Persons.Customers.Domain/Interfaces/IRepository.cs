using Persons.Customers.Domain.Repositories;

namespace Persons.Customers.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
    }
}