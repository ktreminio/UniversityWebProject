using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.PropertyMapping;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping
{
    public interface IStudentPropertyMappingService : IPropertyMappingService<StudentDto, Student>
    {
    }
}
