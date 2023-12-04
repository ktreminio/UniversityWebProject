﻿namespace Kevin.Treminio.University.Service.Domain.Entities
{
    public partial class Student
    {
        public Guid StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}