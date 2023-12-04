using Kevin.Treminio.University.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kevin.Treminio.University.Service.Infrastructure.Persistence.Contexts
{
    public partial class UniversityContext : DbContext
    {
        public void EnsureSeedDataForContext()
        {
            Database.EnsureDeleted();
            Database.Migrate();
            SaveChanges();

            List<Course> courses = new List<Course>
            {
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = "Chemistry",
                    Credits = 3
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = "Microeconomics",
                    Credits = 3
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = "Macroeconomics",
                    Credits = 3
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = "Calculus",
                    Credits = 4
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = "Trigonometry",
                    Credits = 4
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = "Composition",
                    Credits = 3
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Title = "Literature",
                    Credits = 4
                }
            };

            List<Student> students = new List<Student>
            {
                new Student
                {
                    StudentId = Guid.NewGuid(),
                    FirstName = "Carson",
                    LastName = "Alexander",
                    BirthDate = DateTime.Parse("2005-09-01"),
                    Email = "carson@mail.com",
                    Gender = "Male",
                    Address = "123 Main St",
                    Enrollments = new List<Enrollment>() 
                    {
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[0].CourseId,
                            Grade = 70,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[1].CourseId,
                            Grade = 80,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[2].CourseId,
                            Grade = 90,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        }
                    }
                },
                new Student
                {
                    StudentId = new Guid("9d6ed0c8-7f7a-4f4a-8c9e-9e1d5a0f1e1b"),
                    FirstName = "Meredith",
                    LastName = "Alonso",
                    BirthDate = DateTime.Parse("2002-09-01"),
                    Email = "meredith@mail.com",
                    Gender = "Male",
                    Address = "34 Center St",
                    Enrollments = new List<Enrollment>()
                    {
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[3].CourseId,
                            Grade = 75,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[4].CourseId,
                            Grade = 67,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[5].CourseId,
                            Grade = 96,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        }
                    }
                },
                new Student
                {
                    StudentId = new Guid("9d6ed0c8-7f7a-4f4a-8c9e-9e1d5a0f1e1c"),
                    FirstName = "Arturo",
                    LastName = "Anand",
                    BirthDate = DateTime.Parse("2003-09-01"),
                    Email = "arturo@mail.com",
                    Gender = "Male",
                    Address = "56 East St",
                    Enrollments = new List<Enrollment>()
                    {
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[6].CourseId,
                            Grade = 88,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[0].CourseId,
                            Grade = 90,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[1].CourseId,
                            Grade = 77,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        }
                    }
                },
                new Student
                {
                    StudentId = new Guid("9d6ed0c8-7f7a-4f4a-8c9e-9e1d5a0f1e1d"),
                    FirstName = "Gytis",
                    LastName = "Barzdukas",
                    BirthDate = DateTime.Parse("2002-09-01"),
                    Email = "gytis@mail.com",
                    Gender = "Female",
                    Address = "78 West St",
                    Enrollments = new List<Enrollment>()
                    {
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[2].CourseId,
                            Grade = 90,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[3].CourseId,
                            Grade = 80,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[4].CourseId,
                            Grade = 70,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        }
                    }
                },
                new Student
                {
                    StudentId = new Guid("9d6ed0c8-7f7a-4f4a-8c9e-9e1d5a0f1e1e"),
                    FirstName = "Yan",
                    LastName = "Li",
                    BirthDate = DateTime.Parse("2002-09-01"),
                    Email = "yan@mail.com",
                    Gender = "Female",
                    Address = "90 South St",
                    Enrollments = new List<Enrollment>()
                    {
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[5].CourseId,
                            Grade = 80,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[6].CourseId,
                            Grade = 90,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[0].CourseId,
                            Grade = 100,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        }
                    }
                },
                new Student
                {
                    StudentId = new Guid("9d6ed0c8-7f7a-4f4a-8c9e-9e1d5a0f1e1f"),
                    FirstName = "Peggy",
                    LastName = "Justice",
                    BirthDate = DateTime.Parse("2001-09-01"),
                    Email = "peggy@mail.com",
                    Gender = "Female",
                    Address = "12 North St",
                    Enrollments = new List<Enrollment>()
                    {
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[1].CourseId,
                            Grade = 75,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[2].CourseId,
                            Grade = 80,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[3].CourseId,
                            Grade = 90,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        }
                    }
                },
                new Student
                {
                    StudentId = new Guid("9d6ed0c8-7f7a-4f4a-8c9e-9e1d5a0f1e1g"),
                    FirstName = "Laura",
                    LastName = "Norman",
                    BirthDate = DateTime.Parse("2003-09-01"),
                    Email = "laura@mail.com",
                    Gender = "Female",
                    Address = "12 North St, FL",
                    Enrollments = new List<Enrollment>()
                    {
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[4].CourseId,
                            Grade = 80,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[5].CourseId,
                            Grade = 90,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        },
                        new Enrollment
                        {
                            EnrollmentId = Guid.NewGuid(),
                            CourseId = courses[6].CourseId,
                            Grade = 100,
                            EnrollmentDate = DateTime.Parse("2018-09-01")
                        }
                    }
                }
            };

            List<Instructor> instructors = new List<Instructor>
            {
                new Instructor
                {
                    InstructorId = Guid.NewGuid(),
                    FirstName = "Kim",
                    LastName = "Abercrombie",
                    Email = "kim@mail.com",
                    CourseAssignments = new List<CourseAssignment>()
                    {
                        new CourseAssignment
                        {
                            CourseId = courses[0].CourseId
                        },
                        new CourseAssignment
                        {
                            CourseId = courses[1].CourseId
                        },
                        new CourseAssignment
                        {
                            CourseId = courses[2].CourseId
                        }
                    }
                },
                new Instructor
                {
                    InstructorId = Guid.NewGuid(),
                    FirstName = "Fadi",
                    LastName = "Fakhouri",
                    Email = "fadi@mail.com",
                    CourseAssignments = new List<CourseAssignment>()
                    {
                        new CourseAssignment
                        {
                            CourseId = courses[3].CourseId
                        },
                        new CourseAssignment
                        {
                            CourseId = courses[4].CourseId
                        },
                        new CourseAssignment
                        {
                            CourseId = courses[5].CourseId
                        }
                    }
                },
                new Instructor
                {
                    InstructorId = Guid.NewGuid(),
                    FirstName = "Roger",
                    LastName = "Harui",
                    Email = "roger@mail.com",
                    CourseAssignments = new List<CourseAssignment>()
                    {
                        new CourseAssignment
                        {
                            CourseId = courses[6].CourseId
                        }
                    }
                }
            };

            Courses.AddRange(courses);
            Students.AddRange(students);
            Instructors.AddRange(instructors);
            SaveChanges();
        }
    }
}
