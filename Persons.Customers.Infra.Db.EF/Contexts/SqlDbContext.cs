using GoHead.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persons.Customers.Domain.Abstractions;
using Persons.Customers.Domain.Entities;
using Persons.Customers.Domain.Extensions;
using Persons.Customers.Domain.Repositories;
using Persons.Customers.Infra.Db.EF.Extensions;
using System.Reflection;

namespace Persons.Customers.Infra.Db.EF.Contexts;

public class SqlDbContext : DbContext, IUnitOfWork
{
    public DbSet<Customer> Customers { get; set; }

    private readonly IMediator mediator;

    public SqlDbContext(DbContextOptions<SqlDbContext> options, IMediator mediator) : base(options)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies(false);
    }

    public void OnBeforeSaveChanges()
    {
        ChangeTracker.DetectChanges();

        GetEntitiesAdded().ToList()
            .ForEach(x => x.Entity.SetCreatedAtAndCreatedBy());

        GetEntitiesModified().ToList()
            .ForEach(m => m.Entity.SetUpdatedAtAndUpdatedBy());
    }

    private IEnumerable<EntityEntry<Entity>> GetEntitiesModified()
        => ChangeTracker.Entries<Entity>().Where(x => x.State == EntityState.Modified);

    private IEnumerable<EntityEntry<Entity>> GetEntitiesAdded()
        => ChangeTracker.Entries<Entity>().Where(x => x.State == EntityState.Added);

    public async Task<Result<Exception, bool>> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            OnBeforeSaveChanges();

            int result = await base.SaveChangesAsync(cancellationToken);

            await mediator.DispatchDomainEventsAsync(this);

            return result > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}