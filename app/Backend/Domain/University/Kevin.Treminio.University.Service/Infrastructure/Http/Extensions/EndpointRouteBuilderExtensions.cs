using Kevin.Treminio.University.Service.Infrastructure.Http.EndpointHandlers;
using Microsoft.AspNetCore.Authorization;

namespace Kevin.Treminio.University.Service.Infrastructure.Http.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterStudentsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var studentsEndpoints = endpointRouteBuilder
                .MapGroup("api/students")
                .WithTags("Students")
                .RequireAuthorization();

            studentsEndpoints.MapGet("", StudentsHandlers.GetStudentsAsync)
                .WithName("GetStudents")
                .WithOpenApi()
                .RequireAuthorization(new AuthorizeAttribute { Roles = "realm-role" });

            studentsEndpoints.MapGet("/{studentId:guid}", StudentsHandlers.GetStudentByStudentIdAsync)
                .WithName("GetStudent")
                .WithOpenApi()
                .RequireAuthorization(new AuthorizeAttribute { Roles = "client-role" });

            studentsEndpoints.MapPost("", StudentsHandlers.CreateStudentAsync)
                .ProducesValidationProblem(422)
                .WithName("CreateStudent")
                .WithOpenApi();

            studentsEndpoints.MapDelete("/{studentId:guid}", StudentsHandlers.DeleteStudentAsync)
                .WithName("DeleteStudent")
                .WithOpenApi();

            studentsEndpoints.MapPut("/{studentId:guid}", StudentsHandlers.UpdateStudentAsync)
                .ProducesValidationProblem(422)
                .WithName("UpdateStudent")
                .WithOpenApi();
        }

        public static void ResgisterStudentsCollectionEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var studentsCollectionEndpoints = endpointRouteBuilder
                .MapGroup("api/studentscollection")
                .WithTags("StudentsCollection");

            studentsCollectionEndpoints.MapPost("", StudentsCollectionHandlers.CreateStudentCollectionAsync)
                .WithName("CreateStudentCollection")
                .WithOpenApi();

            studentsCollectionEndpoints.MapGet("", StudentsCollectionHandlers.GetStudentsCollectionAsync)
                .WithName("GetStudentsCollection")
                .WithOpenApi();
        }

        public static void ResgiterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterStudentsEndpoints();
            app.ResgisterStudentsCollectionEndpoints();
        }
    }
}
