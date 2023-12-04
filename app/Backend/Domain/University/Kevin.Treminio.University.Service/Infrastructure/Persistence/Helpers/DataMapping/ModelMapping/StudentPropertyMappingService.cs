using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.PropertyMapping;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping
{
    public class StudentPropertyMappingService : PropertyMappingService<StudentDto, Student>, IStudentPropertyMappingService
    {
        private static Dictionary<string, PropertyMappingValue> _studentPropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new PropertyMappingValue(new List<string>() { "StudentId" } ) },
                { "Name", new PropertyMappingValue(new List<string>() { "FirstName" , "LastName" } )},
                { "Gender", new PropertyMappingValue(new List<string>() { "Gender" } )},
                { "Age", new PropertyMappingValue(new List<string>() { "DateOfBirth" } , true) },
            };

        public StudentPropertyMappingService() : base(_studentPropertyMapping) { }
    }
}
