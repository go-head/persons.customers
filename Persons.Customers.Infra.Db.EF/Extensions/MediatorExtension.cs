using MediatR;
using Persons.Customers.Domain.Abstractions;
using Persons.Customers.Infra.Db.EF.Contexts;

namespace Persons.Customers.Infra.Db.EF.Extensions;

internal static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(this IMediator mediator, SqlDbContext ctx)
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<AggregateRoot>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await mediator.Publish(domainEvent);
    }
}