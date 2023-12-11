using FluentValidation.AspNetCore;
using Kevin.Treminio.University.Service.Application.Interfaces;
using Kevin.Treminio.University.Service.Application.Mappers;
using Kevin.Treminio.University.Service.Application.Services;
using Kevin.Treminio.University.Service.Application.Validators;

namespace Kevin.Treminio.University.Service.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(StudentMapper));
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentForCreationDtoValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentForUpdateDtoValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentResourceParametersValidator>());

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CourseForCreationDtoValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CourseForUpdateDtoValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CourseResourceParametersValidator>());

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EnrollmentForUpdateDtoValidator>());

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<InstructorForCreationDtoValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<InstructorForUpdateDtoValidator>());

            services.AddTransient<IValidationService, ValidationService>();
            services.AddScoped<IUniversityApplicationService, UniversityApplicationService>();
        }
    }
}
