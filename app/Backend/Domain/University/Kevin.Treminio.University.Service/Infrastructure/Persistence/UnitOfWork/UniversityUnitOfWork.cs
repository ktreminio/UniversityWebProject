using Kevin.Treminio.University.Service.Domain.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.UnitOfWork
{
    public class UniversityUnitOfWork : UnitOfWork
    {
        public IStudentRepository Student { get; }
        public IInstructorRepository Instructor { get; }
        public ICourseRepository Course { get; }
        public UniversityContext _context { get; }

        public UniversityUnitOfWork(
            UniversityContext context, 
            IStudentRepository student, 
            IInstructorRepository instructor, 
            ICourseRepository course
        ) : base(context)
        {
            _context = context;
            Student = student;
            Instructor = instructor;
            Course = course;
        }

    }
}
