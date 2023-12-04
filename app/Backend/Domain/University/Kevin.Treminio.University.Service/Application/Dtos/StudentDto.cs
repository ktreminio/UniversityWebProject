namespace Kevin.Treminio.University.Service.Application.Dtos
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
    }
}
