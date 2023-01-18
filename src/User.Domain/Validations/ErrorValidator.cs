using FluentValidation;
using User.Domain.Entities;

namespace User.Domain.Validations
{
    public class ErrorValidator : AbstractValidator<Error>
    {
        public ErrorValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .WithMessage("Error can't be nulll");

            RuleFor(x => x.Date)
                .NotNull()
                .WithMessage("Property Date from Erro entity can't be null");
        }
    }
}
