using FluentValidation;
using User.Domain.VOs;

namespace User.Domain.Validations
{
    public class NameValidator : AbstractValidator<Name>
    {
        public NameValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("The Value object Name can't be empty.")

                .NotNull()
                .WithMessage("The Value object Name can't be null.");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("The first name can't be empty.")

                .NotNull()
                .WithMessage("The first name can't be null.")

                .MinimumLength(3)
                .WithMessage("Minimum characters is 3.")

                .MaximumLength(50)
                .WithMessage("Maximum characters is 50.");

            RuleFor(x => x.LastName)
                .MinimumLength(0)
                .WithMessage("Minimum characters is 0.")

                .MaximumLength(50)
                .WithMessage("Maximum characters is 50.");
        }
    }
}
