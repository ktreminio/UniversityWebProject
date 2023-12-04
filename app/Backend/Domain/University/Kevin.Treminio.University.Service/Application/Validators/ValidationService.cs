using FluentValidation;
using FluentValidation.Results;
using Kevin.Treminio.University.Service.Application.Dtos;
using Kevin.Treminio.University.Service.Application.Interfaces;

namespace Kevin.Treminio.University.Service.Application.Validators
{
    public class ValidationService : IValidationService
    {
        private readonly IValidator<StudentForCreationDto> _studentForCreationDtoValidator;
        private readonly IValidator<StudentForUpdateDto> _studentForUpdateDtoValidator;
        private readonly IValidator<StudentResourceParameters> _studentResourceParametersValidator;

        private readonly IValidator<CourseForCreationDto> _courseForCreationDtoValidator;
        private readonly IValidator<CourseForUpdateDto> _courseForUpdateDtoValidator;
        private readonly IValidator<CourseResourceParameters> _courseResourceParametersValidator;

        private readonly IValidator<EnrollmentForUpdateDto> _enrollmentForUpdateDtoValidator;

        private readonly IValidator<InstructorForCreationDto> _instructorForCreationDtoValidator;
        private readonly IValidator<InstructorForUpdateDto> _instructorForUpdateDtoValidator; 

        public ValidationService(
            IValidator<StudentForCreationDto> studentForCreationDtoValidator,
            IValidator<StudentForUpdateDto> studentForUpdateDtoValidator,
            IValidator<StudentResourceParameters> studentResourceParametersValidator,
            IValidator<CourseForCreationDto> courseForCreationDtoValidator,
            IValidator<CourseForUpdateDto> courseForUpdateDtoValidator,
            IValidator<CourseResourceParameters> courseResourceParametersValidator,
            IValidator<EnrollmentForUpdateDto> enrollmentForUpdateDtoValidator,
            IValidator<InstructorForCreationDto> instructorForUpdateDtoValidator,
            IValidator<InstructorForUpdateDto> instructorForCreationDtoValidator
        )
        {
            _studentForCreationDtoValidator = studentForCreationDtoValidator;
            _studentForUpdateDtoValidator = studentForUpdateDtoValidator;
            _studentResourceParametersValidator = studentResourceParametersValidator;
            _courseForUpdateDtoValidator = courseForUpdateDtoValidator;
            _courseForCreationDtoValidator = courseForCreationDtoValidator;
            _courseResourceParametersValidator = courseResourceParametersValidator;
            _enrollmentForUpdateDtoValidator = enrollmentForUpdateDtoValidator;
            _instructorForUpdateDtoValidator = instructorForCreationDtoValidator;
            _instructorForCreationDtoValidator = instructorForUpdateDtoValidator;
        }

        public ValidationResult ValidateCourseCreation(CourseForCreationDto dto)
        {
            return _courseForCreationDtoValidator.Validate(dto);
        }

        public ValidationResult ValidateCourseResourceParameters(CourseResourceParameters dto)
        {
            return _courseResourceParametersValidator.Validate(dto);
        }

        public ValidationResult ValidateCourseUpdate(CourseForUpdateDto dto)
        {
            return _courseForUpdateDtoValidator.Validate(dto);
        }

        public ValidationResult ValidateEnrollmentUpdate(EnrollmentForUpdateDto dto)
        {
            return _enrollmentForUpdateDtoValidator.Validate(dto);
        }

        public ValidationResult ValidateInstructorCreation(InstructorForCreationDto dto)
        {
            return _instructorForCreationDtoValidator.Validate(dto);
        }

        public ValidationResult ValidateInstructorUpdate(InstructorForUpdateDto dto)
        {
            return _instructorForUpdateDtoValidator.Validate(dto);
        }

        public ValidationResult ValidateStudentCreation(StudentForCreationDto dto)
        {
            return _studentForCreationDtoValidator.Validate(dto);
        }

        public ValidationResult ValidateStudentResourceParameters(StudentResourceParameters dto)
        {
            return _studentResourceParametersValidator.Validate(dto);
        }

        public ValidationResult ValidateStudentUpdate(StudentForUpdateDto dto)
        {
            return _studentForUpdateDtoValidator.Validate(dto);
        }
    }
}
