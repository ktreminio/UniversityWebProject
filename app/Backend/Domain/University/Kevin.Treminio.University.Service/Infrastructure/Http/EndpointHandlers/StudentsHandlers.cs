using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Application.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.TypeHelper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.EndpointHandlers
{
    public static class StudentsHandlers
    {
        public static async Task<Results<BadRequest, Ok<IEnumerable<ExpandoObject>>, Ok<LinkedCollectionResource>, Ok<List<StudentDto>>>> GetStudentsAsync(
            [FromServices] IUniversityApplicationService _universityApplicationService,
            [FromServices] IStudentPropertyMappingService _studentPropertyMappingService,
            [FromServices] ITypeHelperService _typeHelperService,
            [FromServices] IHttpContextAccessor _httpContextAccessor,
            [FromHeader(Name = "Accept")] string? mediaType,
            [AsParameters] StudentResourceParameters studentsResourceParameters
        )
        {
            if (!_studentPropertyMappingService.ValidMappingExistsFor(studentsResourceParameters.OrderBy) || !_typeHelperService.TypeHasProperties<StudentDto>(studentsResourceParameters.Fields))
            {
                return TypedResults.BadRequest();
            }

            var result = await _universityApplicationService.GetStudentsAsync(studentsResourceParameters);
            _httpContextAccessor.HttpContext.Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.PaginationMetadata, new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));


            switch (mediaType)
            {
                case "application/vnd.erick.hateoas+json":
                    return TypedResults.Ok(result.linkedCollectionResource);
                default:
                    return TypedResults.Ok(result.ShapedStudents);
            }
        }
    }
}
