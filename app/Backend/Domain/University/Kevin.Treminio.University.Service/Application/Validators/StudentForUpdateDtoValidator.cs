using FluentValidation;
using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Application.Validators
{
    public class StudentForUpdateDtoValidator : AbstractValidator<StudentForUpdateDto>
    {
        public StudentForUpdateDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
