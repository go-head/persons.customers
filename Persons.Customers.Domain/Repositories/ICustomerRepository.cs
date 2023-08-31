using GoHead.Domain;
using Persons.Customers.Domain.Entities;
using Persons.Customers.Domain.Interfaces;
using System.Linq.Expressions;

namespace Persons.Customers.Domain.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> ExistsAsync(string documentNumber);

        Task<Customer?> GetByDocumentNumberAsync(string documentNumber);

        Task<Result<Exception, Customer>> AddCustomerAsync(Customer customer);

        IEnumerable<Customer> Get(
            Expression<Func<Customer, bool>>? filter = null,
            Func<IQueryable<Customer>, IOrderedQueryable<Customer>>? orderBy = null,
            string includeProperties = "");
    }
}