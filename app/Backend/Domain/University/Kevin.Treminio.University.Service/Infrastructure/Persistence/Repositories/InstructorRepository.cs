using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Domain.Interfaces;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        public Task AddInstructorAsync(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        public Task AssignedCourseAsync(Guid instructorId, Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInstructorAsync(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Instructor>> GetAllAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public Task<Instructor> GetInstructorAsync(Guid instructorId)
        {
            throw new NotImplementedException();
        }

        public Task<Instructor> UpdateInstructorAsync(Instructor instructor)
        {
            throw new NotImplementedException();
        }
    }
}
