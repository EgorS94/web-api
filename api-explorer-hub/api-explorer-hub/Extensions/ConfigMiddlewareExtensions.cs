using api_explorer_hub.Middleware;
using Microsoft.AspNetCore.Builder;

namespace api_explorer_hub.Extensions
{
    public static class ConfigMiddlewareExtensions
    {
        public static IApplicationBuilder UseConfigMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ConfigMiddleware>();
        }
    }
}
