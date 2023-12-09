using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Domain.Entities;
using Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.Paged;
using System.Dynamic;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public class StudentLinksBuilder : IStudentLinksBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;
        public StudentLinksBuilder(
            IHttpContextAccessor httpContextAccessor, 
            LinkGenerator linkGenerator
        )
        {
            _httpContextAccessor = httpContextAccessor;
            _linkGenerator = linkGenerator;
        }
        public List<LinkDto> CreateDocumentationLinksForStudent(Guid studentId, string fields)
        {
            var links = new List<LinkDto>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext!, "GetStudent", new { studentId }), "self", "GET"));
            }
            else
            {
                links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext!, "GetStudent", new { studentId, fields }), "self", "GET"));
            }

            links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext!, "DeleteStudent", new { studentId }), "delete_student", "DELETE"));
            links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext!, "UpdateStudent", new { studentId }), "update_student", "PUT"));

            return links;
        }

        public IEnumerable<IDictionary<string, object>> CreateDocumentationLinksForStudentShapeData(IEnumerable<ExpandoObject> shapedStudents, StudentResourceParameters studentResourceParameters)
        {
            var shapedStudentWithLinks = shapedStudents.Select(student =>
            {
                IDictionary<string,object> studentAsDictionary = new Dictionary<string, object>((student as IDictionary<string,object>));
                var studentLinks = CreateDocumentationLinksForStudent((Guid)studentAsDictionary["StudentId"], studentResourceParameters.Fields);
                studentAsDictionary.Add("links", studentLinks);

                return studentAsDictionary;
            });

            return shapedStudentWithLinks.ToList();
        }

        public IEnumerable<LinkDto> CreatePagedLinksForStudnets(StudentResourceParameters studentResourceParameters, bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {
                new LinkDto(CreateStudentCollectionResourceUri(studentResourceParameters, ResourceUriType.Current), "self", "GET")
            };

            if (hasNext)
            {
                links.Add(new LinkDto(CreateStudentCollectionResourceUri(studentResourceParameters, ResourceUriType.NextPage), "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(new LinkDto(CreateStudentCollectionResourceUri(studentResourceParameters, ResourceUriType.PreviousPage), "previousPage", "GET"));
            }

            return links;
        }

        public string CreateStudentCollectionResourceUri(StudentResourceParameters studentResourceParameters, ResourceUriType type)
        {
            switch(type)
            {
                case ResourceUriType.PreviousPage:
                    return _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext!, "GetStudents", 
                        new 
                        {
                            fields = studentResourceParameters.Fields,
                            orderBy = studentResourceParameters.OrderBy,
                            searchQuery = studentResourceParameters.SearchQuery,
                            gender = studentResourceParameters.Gender,
                            pageNumber = studentResourceParameters.PageNumber - 1, 
                            pageSize = studentResourceParameters.PageSize 
                        })!;
                case ResourceUriType.NextPage:
                    return _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext!, "GetStudents", 
                        new
                        {
                            fields = studentResourceParameters.Fields,
                            orderBy = studentResourceParameters.OrderBy,
                            searchQuery = studentResourceParameters.SearchQuery,
                            gender = studentResourceParameters.Gender,
                            pageNumber = studentResourceParameters.PageNumber + 1, 
                            pageSize = studentResourceParameters.PageSize 
                        })!;
                default:
                    return _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext!, "GetStudents", 
                        new
                        {
                            fields = studentResourceParameters.Fields,
                            orderBy = studentResourceParameters.OrderBy,
                            searchQuery = studentResourceParameters.SearchQuery,
                            gender = studentResourceParameters.Gender,
                            pageNumber = studentResourceParameters.PageNumber, 
                            pageSize = studentResourceParameters.PageSize 
                        })!;
            }
        }

        public PaginationMetadata GetPaginationMetadata(PagedList<Student> students, StudentResourceParameters studentResourceParameters)
        {
            PaginationMetadata paginationMetadata = new PaginationMetadata
            {
                PreviousPageLink = students.HasPrevious ? CreateStudentCollectionResourceUri(studentResourceParameters, ResourceUriType.PreviousPage) : null,
                NextPageLink = students.HasNext ? CreateStudentCollectionResourceUri(studentResourceParameters, ResourceUriType.NextPage) : null,
                CurrentPage = students.CurrentPage,
                PageSize = students.PageSize,
                TotalPages = students.TotalPages,
                TotalCount = students.TotalCount
            };

            return paginationMetadata;
        }
    }
}
