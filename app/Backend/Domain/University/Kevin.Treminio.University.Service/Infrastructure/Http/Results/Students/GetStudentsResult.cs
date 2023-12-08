using Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.Paged;
using System.Dynamic;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.Results.Students
{
    public class GetStudentsResult
    {
        public IEnumerable<ExpandoObject> ShapedStudents { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
        public LinkedCollectionResource linkedCollectionResource { get; set; }
    }
}
