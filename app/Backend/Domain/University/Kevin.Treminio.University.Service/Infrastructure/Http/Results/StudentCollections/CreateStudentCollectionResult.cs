using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.Results.StudentCollections
{
    public class CreateStudentCollectionResult
    {
        public IEnumerable<StudentDto> StudentsCollection { get; set; }
        public string StudentIdsAsString { get; set; }
    }
}
