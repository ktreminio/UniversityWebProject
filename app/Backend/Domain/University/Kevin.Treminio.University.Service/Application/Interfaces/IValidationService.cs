using FluentValidation.Results;
using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Application.Interfaces
{
    public interface IValidationService
    {
        ValidationResult ValidateStudentCreation(StudentForCreationDto dto);
        ValidationResult ValidateStudentUpdate(StudentForUpdateDto dto);
        ValidationResult ValidateStudentResourceParameters(StudentResourceParameters dto);
        ValidationResult ValidateCourseCreation(CourseForCreationDto dto);
        ValidationResult ValidateCourseUpdate(CourseForUpdateDto dto);
        ValidationResult ValidateCourseResourceParameters(CourseResourceParameters dto);
        ValidationResult ValidateEnrollmentUpdate(EnrollmentForUpdateDto dto);
        ValidationResult ValidateInstructorCreation(InstructorForCreationDto dto);
        ValidationResult ValidateInstructorUpdate(InstructorForUpdateDto dto);
    }
}
