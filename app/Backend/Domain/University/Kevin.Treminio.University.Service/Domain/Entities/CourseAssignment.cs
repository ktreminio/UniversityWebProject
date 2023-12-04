namespace Kevin.Treminio.University.Service.Domain.Entities
{
    public partial class CourseAssignment
    {
        public Guid CourseId { get; set; }
        public Guid InstructorId { get; set; }
        public virtual Course? Course { get; set; }
        public virtual Instructor? Instructor { get; set; }
    }
}
