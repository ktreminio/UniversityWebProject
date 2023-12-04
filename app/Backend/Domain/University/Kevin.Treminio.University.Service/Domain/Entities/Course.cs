namespace Kevin.Treminio.University.Service.Domain.Entities
{
    public partial class Course
    {
        public Guid CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
        public virtual ICollection<CourseAssignment>? CourseAssignments { get; set; }
    }
}
