using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.Paged;

namespace Kevin.Treminio.University.Service.Domain.Interfaces
{
    public interface ICourseRepository
    {
        Task AddCourseAsync(Course course);
        Task DeleteCourseAsync(Course course);
        Task<Course> GetCourseAsync(Guid courseId);
        Task<PagedList<Course>> GetAllAsync(CourseResourceParameters parameters);
        Task<IEnumerable<Course>> GetAllAsync(Guid studentId);
        Task<Course> UpdateCourseAsync(Course course);
    }
}
