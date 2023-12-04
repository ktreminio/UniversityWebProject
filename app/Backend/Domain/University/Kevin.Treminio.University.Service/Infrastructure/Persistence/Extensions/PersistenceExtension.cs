using Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Extensions
{
    public class PersistenceOptions
    {
        public string? ConnectionString { get; set; }
    }
    public static class PersistenceExtension
    {
        public static void UseSeedData(this IHost app)
        {
            var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<UniversityContext>();
                context.EnsureSeedDataForContext();
            }
        }
        public static void AddPersistence(this IServiceCollection services, Action<PersistenceOptions> configure)
        {
            var options = new PersistenceOptions();
            configure(options);

            services.AddDbContext<UniversityContext>(o => o.UseSqlServer(options.ConnectionString));
        }
    }
}
