using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persons.Customers.Application.Commands.Create;
using Persons.Customers.Domain.Repositories;
using Persons.Customers.Infra.Db.EF.Contexts;
using Persons.Customers.Infra.Db.EF.Options;
using Persons.Customers.Infra.Db.EF.Repositories;

namespace Persons.Customers.Infra.CrossCutting.IoC.Modules;

public static class InfraModule
{
    public static IServiceCollection RegisterInfraModules(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly));

        services.RegisterInfraDbEF(configuration);

        return services;
    }

    private static IServiceCollection RegisterInfraDbEF(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SqlDbContext>((serviceProvider, dbContext) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

            dbContext.UseSqlServer(databaseOptions.ConnectionString, sqlServerAction =>
            {
                sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
                sqlServerAction.MigrationsAssembly("Persons.Customers.Infra.Db.EF");
            });

            dbContext.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
            dbContext.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}