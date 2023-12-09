using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Domain.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Extensions;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.Paged;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityContext _context;
        private readonly IStudentPropertyMappingService _studentPropertyMappingService;

        public StudentRepository(
            UniversityContext context,
            IStudentPropertyMappingService studentPropertyMappingService
        )
        {
            _context = context;
            _studentPropertyMappingService = studentPropertyMappingService;
        }

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

        public Task<Student> GetStudentAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetStudentsAsync(IEnumerable<Guid> studentIds)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<Student>> GetStudentsAsync(StudentResourceParameters parameters)
        {
            var collectionBeforePaging = _context.Students
                .ApplySort(parameters.OrderBy, _studentPropertyMappingService.GetPropertyMapping());

            if (!string.IsNullOrEmpty(parameters.SearchQuery))
            {
                var searchQueryForWhereClause = parameters.SearchQuery.Trim().ToLower();

                collectionBeforePaging = collectionBeforePaging
                    .Where(x => x.Gender.ToLower().Contains(searchQueryForWhereClause)
                    || x.FirstName.ToLower().Contains(searchQueryForWhereClause)
                    || x.LastName.ToLower().Contains(searchQueryForWhereClause));
            }

            if (!string.IsNullOrEmpty(parameters.Gender))
            {
                var genderForWhereClause = parameters.Gender.Trim().ToLower();
                collectionBeforePaging = collectionBeforePaging.Where(s => s.Gender.ToLower() == genderForWhereClause);
            }

            return await PagedList<Student>.CreateAsync(collectionBeforePaging, parameters.PageNumber.Value, parameters.PageSize.Value);
        }

        public Task UpdateEnrollmentForStudentAsync(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGradeForCourse(Guid studentId, Guid courseId, EnrollmentForUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
