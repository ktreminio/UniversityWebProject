using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.Extensions
{
    public static class HttpExtensions
    {
        public static void AddHttpResult(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.Configure<JsonOptions>(
                options => { options.SerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase; }
            );
            services.AddSwaggerDocumentation();
            services.AddScoped<IStu>
        }
    }
}
