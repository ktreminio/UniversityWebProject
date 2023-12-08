using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.Results.StudentCollections
{
    public class GetStudentCollectionResult
    {
        public IEnumerable<StudentDto> StudentsCollection { get; set; }
        public bool StudentFound { get; set; }
    }
}
