namespace Kevin.Treminio.University.Service.Application.Dtos
{
    public class EnrollmentForCreationDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public int Grade { get; set; } = 0;
        public DateTime? EnrollmentDate { get; set; }
    }
}
