using System.Dynamic;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.Results.Students
{
    public class GetStudentByStudentIdResult
    {
        public ExpandoObject ShapedStudent { get; set; }
        public IDictionary<string, object> LinksResource { get; set; }
    }
}
