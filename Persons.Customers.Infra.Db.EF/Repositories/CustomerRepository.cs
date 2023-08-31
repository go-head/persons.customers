using GoHead.Domain;
using Microsoft.EntityFrameworkCore;
using Persons.Customers.Domain.Entities;
using Persons.Customers.Domain.Repositories;
using Persons.Customers.Infra.Db.EF.Contexts;
using System.Linq.Expressions;
using System.Linq;

namespace Persons.Customers.Infra.Db.EF.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly SqlDbContext context;

    public IUnitOfWork UnitOfWork
    {
        get
        {
            return context;
        }
    }

    public CustomerRepository(SqlDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> ExistsAsync(string documentNumber)
    {
        try
        {
            var result = await context.Customers.AnyAsync(x => x.DocumentNumber == documentNumber);

            return result;
        }
        catch
        {
            throw;
        }
    }

    public async Task<Customer?> GetByDocumentNumberAsync(string documentNumber)
    {
        try
        {
            return await context.Customers.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber);
        }
        catch
        {
            throw;
        }
    }

    public async Task<Result<Exception, Customer>> AddCustomerAsync(Customer customer)
    {
        var result = await context.Customers.AddAsync(customer);

        return result.Entity;
    }

    public IEnumerable<Customer> Get(Expression<Func<Customer, bool>>? filter = null,
        Func<IQueryable<Customer>, IOrderedQueryable<Customer>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<Customer> query = context.Customers;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty.Trim());
        }

        if (orderBy != null)
        {
            return orderBy(query).AsNoTracking().ToList();
        }
        else
        {
            return query.AsNoTracking().ToList();
        }
    }

    private string BuildInclude() => $"{nameof(Customer.Document)},{nameof(Customer.Address)}";
}