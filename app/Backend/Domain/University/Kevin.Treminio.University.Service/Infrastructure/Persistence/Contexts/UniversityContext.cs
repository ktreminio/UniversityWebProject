using Kevin.Treminio.University.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts
{
    public partial class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }        

        public virtual DbSet<Instructor> Instructors { get; set; }

        public virtual DbSet<CourseAssignment> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.CourseConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.StudentConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EnrollmentConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CourseAssignmentConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
