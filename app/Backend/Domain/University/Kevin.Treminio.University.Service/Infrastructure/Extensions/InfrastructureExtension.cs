using Kevin.Treminio.University.Service.Infrastructure.Http.Extensions;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Extensions;
using Kevin.Treminio.University.Service.Infrastructure.Security.Extensions;

namespace Kevin.Treminio.University.Service.Infrastructure.Extensions
{
    public class InfrastructureOptions
    {
        public string? ConnectionString { get; set; }
    }
    public static class InfrastructureExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, Action<InfrastructureOptions> configure)
        {
            var options = new InfrastructureOptions();
            configure(options);

            services.AddHttpResult();
            services.AddPersistence(o => o.ConnectionString = options.ConnectionString);
            services.AddSecurity();
        }
    }
}
