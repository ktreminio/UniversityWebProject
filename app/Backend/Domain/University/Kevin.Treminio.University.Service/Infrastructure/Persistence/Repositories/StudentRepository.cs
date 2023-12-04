using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Domain.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.Paged;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public Task AddStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task AssignedCourseAsync(Guid studentId, Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Student>> GetAllAsync(StudentResourceParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEnrollmentForStudentAsync(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
