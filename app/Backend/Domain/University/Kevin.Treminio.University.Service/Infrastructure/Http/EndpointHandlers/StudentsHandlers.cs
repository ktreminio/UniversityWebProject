using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Application.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Kevin.Treminio.University.Service.Infrastructure.Persistence.Helpers.DataMapping.TypeHelper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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

        public static async Task<Results<BadRequest, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<ExpandoObject>, CreatedAtRoute<StudentDto>, Ok<StudentDto>>> CreateStudentAsync(
            [FromServices] IUniversityApplicationService _universityApplicationService,
            [FromBody] StudentForCreationDto student
        )
        {
            if (student == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _universityApplicationService.CreateStudentAsync(student);
            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            Guid studentId = (Guid)(result.ShapedStudent as IDictionary<string, object>)["StudentId"];

            return TypedResults.CreatedAtRoute(result.ShapedStudent, $"GetStudent", new { studentId });
        }

        public static async Task<Results<NotFound, NoContent>> DeleteStudentAsync(
            [FromServices] IUniversityApplicationService _universityApplicationService,
            Guid studentId
        )
        {
            var result = await _universityApplicationService.DeleteStudentAsync(studentId);
            if (!result)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.NoContent();
        }

        public static async Task<Results<BadRequest, NotFound, Ok<ExpandoObject>, Ok<IDictionary<string,object>>, Ok<StudentDto>>> GetStudentByStudentIdAsync(
            [FromServices] IUniversityApplicationService _universityApplicationService,
            [FromServices] ITypeHelperService _typeHelperService,
            [FromHeader(Name = "Accept")] string? mediaType,            
            [AsParameters] string? fields,
            Guid studentId
        )
        {
            if (!_typeHelperService.TypeHasProperties<StudentDto>(fields))
            {
                return TypedResults.BadRequest();
            }

            var result = await _universityApplicationService.GetStudentByStudentIdAsync(studentId, fields);
            if (result == null)
            {
                return TypedResults.NotFound();
            }

            switch (mediaType)
            {
                case "application/vnd.kevin.hateoas+json":
                    return TypedResults.Ok(result.LinksResource);
                default:
                    return TypedResults.Ok(result.ShapedStudent);
            }
        }

        public static async Task<Results<BadRequest, NotFound, NoContent, CreatedAtRoute<StudentDto>, UnprocessableEntity<List<ValidationResult>>, Ok<StudentDto>>> UpdateStudentAsync(
            [FromServices] IUniversityApplicationService _universityApplicationService,
            [FromBody] StudentForUpdateDto student,
            Guid studentId
        )
        {
            if (student == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _universityApplicationService.UpdateStudentAsync(studentId, student);
            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            if(result.Success && result.StudentUpserted != null)
            {
                return TypedResults.CreatedAtRoute(result.StudentUpserted, $"GetStudent", new { studentId = result.StudentUpserted.StudentId });
            }

            return TypedResults.NoContent();
        }
    }
}
