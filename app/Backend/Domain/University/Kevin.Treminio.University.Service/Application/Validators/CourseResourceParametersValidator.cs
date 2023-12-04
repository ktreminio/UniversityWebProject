using FluentValidation;
using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Application.Validators
{
    public class CourseResourceParametersValidator : AbstractValidator<CourseResourceParameters>
    {
        public CourseResourceParametersValidator()
        {
            RuleFor(x => x.Fields).Custom((fields, context) =>
            {
                if (!string.IsNullOrEmpty(fields))
                {
                    var fieldsSplit = fields.Split(',');
                    if (!fieldsSplit.Any(f => f.Trim().Equals("CourseId", StringComparison.OrdinalIgnoreCase)))
                        context.InstanceToValidate.Fields = fields + ",CourseId";
                }
            });
        }
    }
}
