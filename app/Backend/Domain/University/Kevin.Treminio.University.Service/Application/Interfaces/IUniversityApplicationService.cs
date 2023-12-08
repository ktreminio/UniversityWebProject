using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Infrastructure.Http.Results.StudentCollections;
using Kevin.Treminio.University.Service.Infrastructure.Http.Results.Students;

namespace Kevin.Treminio.University.Service.Application.Interfaces
{
    public interface IUniversityApplicationService
    {
        Task<GetStudentsResult> GetAuthorAsync(StudentResourceParameters studentResourceParameters);
        Task<CreateStudentResult> CreateStudentAsync(StudentForCreationDto student);
        Task<bool> DeleteStudentAsync(Guid studentId);
        Task<GetStudentByStudentIdResult> GetStudentByStudentIdAsync(Guid studentId, string fields);
        Task<UpdateStudentResult> UpdateStudentAsync(Guid studentId, StudentForUpdateDto student);
        Task<CreateStudentCollectionResult> CreateStudentCollectionAsync(IEnumerable<StudentForCreationDto> studentCollection);
    }
}
