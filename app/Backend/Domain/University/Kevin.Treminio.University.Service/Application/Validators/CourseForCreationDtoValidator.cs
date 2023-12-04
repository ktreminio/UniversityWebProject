using FluentValidation;
using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Application.Validators
{
    public class CourseForCreationDtoValidator : AbstractValidator<CourseForCreationDto>
    {
        public CourseForCreationDtoValidator()
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
