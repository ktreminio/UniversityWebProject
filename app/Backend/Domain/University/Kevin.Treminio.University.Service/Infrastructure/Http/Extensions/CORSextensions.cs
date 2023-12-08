
namespace Kevin.Treminio.University.Service.Infrastructure.Http.Extensions
{
    public static class CORSExtensions
    {
        public static void AddAllowAllCORS(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllCORS", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination");
                });
            });
        }
        public static void UseAllowAllCORS(this IApplicationBuilder app)
        {
            app.UseCors("AllowAllCORS");
        }
    }
}
