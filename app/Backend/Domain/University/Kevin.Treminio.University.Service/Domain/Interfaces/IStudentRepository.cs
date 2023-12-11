using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.Paged;

namespace Kevin.Treminio.University.Service.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task AddStudentAsync(Student student);
        Task AssignedCourseAsync(Guid studentId, Guid courseId);
        Task UpdateGradeForCourse(Guid studentId, Guid courseId, EnrollmentForUpdateDto dto);
        Task DeleteStudentAsync(Student student);
        Task<Student> GetStudentAsync(Guid studentId);
        Task<IEnumerable<Student>> GetStudentsAsync(List<Guid> studentIds);
        Task<PagedList<Student>> GetStudentsAsync(StudentResourceParameters parameters);
        Task UpdateStudentAsync(Student student);
        Task UpdateEnrollmentForStudentAsync(Enrollment enrollment);
    }
}
