using FluentValidation;
using Entity = User.Domain.Entities;

namespace User.Domain.Validations
{
    public class UserValidator : AbstractValidator<Entity.User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("The entity can't be empty.")

                .NotNull()
                .WithMessage("The entity can't be null.");
        }
    }
}
