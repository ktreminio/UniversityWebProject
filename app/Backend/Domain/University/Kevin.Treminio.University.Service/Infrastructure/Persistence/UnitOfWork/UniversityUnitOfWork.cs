using Kevin.Treminio.University.Service.Domain.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.UnitOfWork
{
    public class UniversityUnitOfWork : UnitOfWork
    {
        public IStudentRepository Students { get; }
        public IInstructorRepository Instructors { get; }
        public ICourseRepository Courses { get; }
        public UniversityContext _context { get; }

        public UniversityUnitOfWork(
            UniversityContext context, 
            IStudentRepository students, 
            IInstructorRepository instructors, 
            ICourseRepository courses
        ) : base(context)
        {
            _context = context;
            Students = students;
            Instructors = instructors;
            Courses = courses;
        }

    }
}
