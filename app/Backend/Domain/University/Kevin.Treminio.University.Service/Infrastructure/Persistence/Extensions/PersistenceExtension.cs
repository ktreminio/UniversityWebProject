using Kevin.Treminio.University.Service.Domain.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.TypeHelper;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Repositories;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.UnitOfWork;
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
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            services.AddScoped<UniversityUnitOfWork>();
            services.AddTransient<IStudentPropertyMappingService, StudentPropertyMappingService>();
            services.AddScoped<ITypeHelperService, TypeHelperService>();
        }
    }
}
