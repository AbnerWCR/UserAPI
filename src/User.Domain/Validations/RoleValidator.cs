using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.VOs;

namespace User.Domain.Validations
{
    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("The Value Object Email can't be empty.")

                .NotNull()
                .WithMessage("The Value Object Email can't be null.");

            RuleFor(x => x.UserRole)
                .NotNull()
                .WithMessage("The user role can't be null.")

                .NotEmpty()
                .WithMessage("The user role can't be empty.")

                .MinimumLength(5)
                .WithMessage("Minimum characters is 5.")

                .MaximumLength(6)
                .WithMessage("Maximum characters is 6.");
        }
    }
}
