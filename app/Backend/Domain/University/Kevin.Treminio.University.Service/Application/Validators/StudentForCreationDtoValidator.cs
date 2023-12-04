using FluentValidation;
using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Application.Validators
{
    public class StudentForCreationDtoValidator : AbstractValidator<StudentForCreationDto>
    {
        public StudentForCreationDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .LessThan(DateTime.Now);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
