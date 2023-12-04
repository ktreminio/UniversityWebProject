using Kevin.Treminio.University.Service.Domain.Entities;

namespace Kevin.Treminio.University.Service.Domain.Interfaces
{
    public interface IInstructorRepository
    {
        Task AddInstructorAsync(Instructor instructor);
        Task AssignedCourseAsync(Guid instructorId, Guid courseId);
        Task DeleteInstructorAsync(Instructor instructor);
        Task<Instructor> GetInstructorAsync(Guid instructorId);
        Task<IEnumerable<Instructor>> GetAllAsync(Guid courseId);
        Task<Instructor> UpdateInstructorAsync(Instructor instructor);
    }
}
