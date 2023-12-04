using Kevin.Treminio.University.Service.Application.Mappers;

namespace Kevin.Treminio.University.Service.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(StudentMapper));
        }
    }
}
