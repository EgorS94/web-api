using api_explorer_hub.Storage;
using Microsoft.OpenApi.Models;

namespace api_explorer_hub.Extensions
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddServiceCollection(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Списка контактов",
                });
            });
            services.AddControllers();
            var stringConnection = configuration.GetConnectionString("SqliteStringConnection");
            services.AddSingleton<IStorage>(new SQLiteStorage(stringConnection));

            services.AddCors(opt =>
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins(configuration["client"]);
                })
            );
            return services;
        }
    }
}
