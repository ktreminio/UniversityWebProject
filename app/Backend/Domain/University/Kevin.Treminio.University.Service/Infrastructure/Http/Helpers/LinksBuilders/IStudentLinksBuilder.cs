using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.Paged;
using System.Dynamic;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public interface IStudentLinksBuilder
    {
        string CreateStudentCollectionResourceUri(StudentResourceParameters studentResourceParameters, ResourceUriType type);
        PaginationMetadata GetPaginationMetadata(PagedList<Student> students, StudentResourceParameters studentResourceParameters);
        List<LinkDto> CreateDocumentationLinksForStudent(Guid studentId, string fields);
        IEnumerable<IDictionary<string, object>> CreateDocumentationLinksForStudentShapeDate(IEnumerable<ExpandoObject> shapedStudents, StudentResourceParameters studentResourceParameters);
        IEnumerable<LinkDto> CreatePagedLinksForStudnets(StudentResourceParameters studentResourceParameters, bool hasNext, bool hasPrevious);
    }
}
