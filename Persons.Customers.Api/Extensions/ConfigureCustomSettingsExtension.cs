using Persons.Customers.Infra.Db.EF.Options;

namespace Persons.Customers.Api.Extensions;

public static class ConfigureCustomSettingsExtension
{
    public static ConfigurationManager AddCustomSettings(this ConfigurationManager manager, WebApplicationBuilder builder)
    {
        //builder.Services.Configure<RabbitConfig>(builder.Configuration.GetSection(nameof(RabbitConfig)));
        //builder.Services.Configure<PersonProducerConfig>(builder.Configuration.GetSection(nameof(PersonProducerConfig)));

        builder.Services.ConfigureOptions<DatabaseOptionsSetup>();

        return manager;
    }
}