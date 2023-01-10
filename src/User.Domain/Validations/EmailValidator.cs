using FluentValidation;
using User.Domain.VOs;

namespace User.Domain.Validations
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("The Value Object Email can't be empty.")

                .NotNull()
                .WithMessage("The Value Object Email can't be null.");

            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage("The email can't be null.")

                .NotEmpty()
                .WithMessage("The email can't be empty.")

                .MinimumLength(10)
                .WithMessage("Minimum characters is 10.")

                .MaximumLength(180)
                .WithMessage("Maximum characters is 180.")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("The email is not valid.");
        }
    }
}
