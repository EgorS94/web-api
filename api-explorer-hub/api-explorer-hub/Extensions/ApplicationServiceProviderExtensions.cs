using api_explorer_hub.Seed;
using api_explorer_hub.Storage;
using Bogus;

namespace api_explorer_hub.Extensions
{
    public static class ApplicationServiceProviderExtensions
    {
        public static IServiceProvider AddCustomService(
            this IServiceProvider services,
            IConfiguration configuration)
        {
            using var scope = services.CreateScope();
            
            var initializer = scope.ServiceProvider.GetRequiredService<IInitializer>();
            initializer.Initialize();

            return services;
        }
    }
}
