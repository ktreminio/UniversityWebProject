using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Domain.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.Paged;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public Task AddCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Course>> GetAllAsync(CourseResourceParameters parameters)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAllAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetCourseAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task<Course> UpdateCourseAsync(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
