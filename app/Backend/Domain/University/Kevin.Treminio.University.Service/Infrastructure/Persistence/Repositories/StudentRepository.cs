using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Domain.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Extensions;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.Paged;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task AssignedCourseAsync(Guid studentId, Guid courseId)
        {
            if (!_context.Enrollments.AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId).Result)
            {
                var enrollment = new Enrollment
                {
                    StudentId = studentId,
                    CourseId = courseId
                };

                await _context.Enrollments.AddAsync(enrollment);
            }
        }

        public async Task DeleteStudentAsync(Student student)
        {
            await Task.FromResult(_context.Students.Remove(student));
        }

        public Task<Student> GetStudentAsync(Guid studentId)
        {
            return _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync(List<Guid> studentIds)
        {
            return await _context.Students.Where(s => studentIds.Contains(s.StudentId))
                .OrderBy(s => s.FirstName)
                .OrderBy(s => s.LastName)
                .ToListAsync();
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

        public async Task UpdateStudentAsync(Student student)
        {
            var studentToUpdate = await GetStudentAsync(student.StudentId);
            if (studentToUpdate != null)
            {
                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.Gender = student.Gender;

            }
        }
    }
}
