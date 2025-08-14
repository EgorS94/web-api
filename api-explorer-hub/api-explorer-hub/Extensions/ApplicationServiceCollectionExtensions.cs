using api_explorer_hub.DataContext;
using api_explorer_hub.Seed;
using api_explorer_hub.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace api_explorer_hub.Extensions
{
    public static class ApplicationServiceCollectionExtensions
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
            services.AddDbContext<SqliteDbContext>(opt => opt.UseSqlite(stringConnection));
            services.AddScoped<IPaginationStorage, SQLitePaginationEfStorage>();
            services.AddScoped<IInitializer, SqliteEfFakerInitializer>();
            //services.AddSingleton<IStorage>(new SQLiteStorage(stringConnection));

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
