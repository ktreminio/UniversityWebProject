using FluentValidation.Results;
using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.Results.Students
{
    public class UpdateStudentResult
    {
        public StudentDto StudentUpserted { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; }
        public bool Success { get; set; }
    }
}
