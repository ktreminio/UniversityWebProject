namespace Kevin.Treminio.University.Service.Application.Dtos
{
    public class StudentForCreationDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
    }
}
