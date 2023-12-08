using FluentValidation.Results;
using System.Dynamic;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.Results.Students
{
    public class CreateStudentResult
    {
        public ExpandoObject ShapedStudent { get; set; }
        public IDictionary<string, object> LinksResource { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; }
        public bool Success { get; set; }
    }
}
