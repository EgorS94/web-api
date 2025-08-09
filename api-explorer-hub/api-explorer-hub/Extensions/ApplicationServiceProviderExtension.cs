using api_explorer_hub.Seed;
using api_explorer_hub.Storage;
using Bogus;

namespace api_explorer_hub.Extensions
{
    public static class ApplicationServiceProviderExtension
    {
        public static IServiceProvider AddCustomService(
            this IServiceProvider services,
            IConfiguration configuration)
        {
            using var scope = services.CreateScope();

            var storage = scope.ServiceProvider.GetService<IStorage>();
            var dbStorage = storage as SQLiteStorage;
            if (dbStorage != null)
            {
                string connectionString = configuration.GetConnectionString("SqliteStringConnection");

                new FakerInitializer(connectionString).Initialize();
            }

            return services;
        }
    }
}
