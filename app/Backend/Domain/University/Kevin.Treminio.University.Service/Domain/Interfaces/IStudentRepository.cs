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
        Task<PagedList<Student>> GetAllAsync(StudentResourceParameters parameters);
        Task UpdateStudentAsync(Student student);
        Task UpdateEnrollmentForStudentAsync(Enrollment enrollment);
    }
}
