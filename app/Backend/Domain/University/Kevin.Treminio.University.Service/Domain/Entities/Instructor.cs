namespace Kevin.Treminio.University.Service.Domain.Entities
{
    public partial class Instructor
    {
        public Guid InstructorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<CourseAssignment>? CourseAssignments { get; set; }
    }
}
