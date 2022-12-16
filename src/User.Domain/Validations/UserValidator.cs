using FluentValidation;
using Entity = User.Domain.Entities;

namespace User.Domain.Validations
{
    public class UserValidator : AbstractValidator<Entity.User>
    {
        public UserValidator()
        {
            // general validation
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("The entity is not empty.")

                .NotNull()
                .WithMessage("The entity is not null.");

            // for the property name of the entity
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The name is not empty.")

                .NotNull()
                .WithMessage("The name is not null.")

                .MaximumLength(3)
                .WithMessage("Minimum characters is 3.")

                .MaximumLength(50)
                .WithMessage("Maximum characters is 50.");

            //for the property email of the entity
            //Validação Email
            RuleFor(x => x.Email)
            .NotNull()
                .WithMessage("The email is not null.")

                .NotEmpty()
                .WithMessage("The email is not empty.")

                .MinimumLength(10)
                .WithMessage("Minimum characters is 10.")

                .MaximumLength(180)
                .WithMessage("Maximum characters is 180.")

                //regular expression for email 
                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("The email is not valid.");

            // for the property password of the entity
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("The password is not empty.")

                .NotNull()
                .WithMessage("The password is not null.")

                .MaximumLength(6)
                .WithMessage("Minimum characters is 6.")

                .MaximumLength(18)
                .WithMessage("Maximum characters is 18.")

                .Matches(@"[A-Z]+")
                .WithMessage("Your password must contain at least one uppercase letter.")

                .Matches(@"[a-z]+")
                .WithMessage("Your password must contain at least one lowercase letter.")
                
                .Matches(@"[0-9]+")
                .WithMessage("Your password must contain at least one number.")

                .Matches(@"(?=.*?[#?!@$%^&*-])")
                .WithMessage("Your password must contain at least one special character.");
        }
    }
}
