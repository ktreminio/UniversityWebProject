using FluentValidation;
using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Application.Validators
{
    public class CourseForUpdateDtoValidator : AbstractValidator<CourseForUpdateDto>
    {
        public CourseForUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Credits)
                .NotEmpty()
                .InclusiveBetween(1, 5);
        }
    }
}
