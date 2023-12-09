using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Application.Interfaces;
using Kevin.Treminio.University.Service.Infrastructure.Http.Helpers.QueryParametersTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.EndpointHandlers
{
    public static class StudentsCollectionHandlers
    {
        public static async Task<Results<BadRequest, NotFound, Ok<IEnumerable<StudentDto>>>> GetStudentsCollectionAsync(
            [FromServices] IUniversityApplicationService universityApplicationService,
            [FromQuery] QueryParameterListGuidsType studentIds
        )
        {
            if (studentIds == null || !studentIds.Items.Any())
            {
                return TypedResults.BadRequest();
            }

            var result = await universityApplicationService.GetStudentsCollectionAsync(studentIds.Items);

            if (!result.StudentFound)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(result.StudentsCollection);
        }
    }
}
