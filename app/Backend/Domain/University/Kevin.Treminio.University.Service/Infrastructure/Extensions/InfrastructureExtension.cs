using Kevin.Treminio.University.Service.Infrastructure.Persistence.Extensions;

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

            services.AddPersistence(o => o.ConnectionString = options.ConnectionString);
        }
    }
}
