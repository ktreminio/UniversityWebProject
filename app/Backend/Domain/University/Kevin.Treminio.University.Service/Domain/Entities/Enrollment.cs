namespace Kevin.Treminio.University.Service.Domain.Entities
{
    public partial class Enrollment
    {
        public Guid EnrollmentId { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public int Grade { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
    }
}
