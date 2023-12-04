using FluentValidation;
using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Application.Validators
{
    public class EnrollmentForUpdateDtoValidator : AbstractValidator<EnrollmentForUpdateDto>
    {
        public EnrollmentForUpdateDtoValidator()
        {
            RuleFor(x => x.Grade)
                .NotEmpty()
                .InclusiveBetween(0, 100);
        }
    }
}
