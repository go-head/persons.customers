namespace Persons.Customers.Api.Extensions
{
    public static class CustomJsonConfigFilesExtension
    {
        public static ConfigurationManager AddCustomJsonConfigFiles(this ConfigurationManager manager, WebApplicationBuilder builder)
        {
            var enviroment = builder.Environment.EnvironmentName;
            builder.Configuration
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{enviroment ?? "Development"}.json", optional: true, reloadOnChange: true);

            return manager;
        }
    }
}