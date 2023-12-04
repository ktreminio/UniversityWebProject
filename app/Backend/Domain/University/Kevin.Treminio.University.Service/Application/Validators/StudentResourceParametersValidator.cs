using FluentValidation;
using Kevin.Treminio.University.Service.Application.Dtos;

namespace Kevin.Treminio.University.Service.Application.Validators
{
    public class StudentResourceParametersValidator : AbstractValidator<StudentResourceParameters>
    {
        public StudentResourceParametersValidator()
        {
            RuleFor(x => x.Fields).Custom((fields, context) =>
            {
                if (!string.IsNullOrEmpty(fields))
                {
                    var fieldsSplit = fields.Split(',');
                    if (!fieldsSplit.Any(f => f.Trim().Equals("StudentId", StringComparison.OrdinalIgnoreCase)))
                        context.InstanceToValidate.Fields = fields + ",StudentId";
                }
            });
        }
    }
}
