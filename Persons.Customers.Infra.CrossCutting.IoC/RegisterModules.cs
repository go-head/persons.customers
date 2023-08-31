using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persons.Customers.Infra.CrossCutting.IoC.Modules;

namespace Persons.Customers.Infra.CrossCutting.IoC
{
    public static class RegisterModules
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration) =>
            services.RegisterInfraModules(configuration);
    }
}