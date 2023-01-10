using FluentValidation;
using User.Domain.VOs;

namespace User.Domain.Validations
{
    public class PasswordValidator : AbstractValidator<Password>
    {
        public PasswordValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("The Value object Password can't be empty.")

                .NotNull()
                .WithMessage("The Value object Password can't be null.");

            RuleFor(x => x.PasswordHash)
                .NotEmpty()
                .WithMessage("The password can't be empty.")

                .NotNull()
                .WithMessage("The password can't be null.")

                .MinimumLength(6)
                .WithMessage("Minimum characters is 6.")

                .MaximumLength(200)
                .WithMessage("Maximum characters is 200.");

            RuleFor(x => x.PasswordText)
                .NotEmpty()
                .WithMessage("The password can't be empty.")

                .NotNull()
                .WithMessage("The password can't be null.")

                .MinimumLength(6)
                .WithMessage("Minimum characters is 6.")

                .MaximumLength(18)
                .WithMessage("Maximum characters is 18.");
        }
    }
}
