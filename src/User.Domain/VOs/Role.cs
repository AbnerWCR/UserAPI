﻿using System.Linq;
using User.Domain.Roles;
using User.Domain.Validations;
using User.Infra.CrossCutting.Exceptions;

namespace User.Domain.VOs
{
    public class Role : BaseValueObject
    {
        public string UserRole { get; private set; }

        public Role()
        {
            
        }

        public void DefaultRole()
        {
            UserRole = UserRoles.PUBLIC;
            Validate();
        }

        public void SetUserAdmin()
        {
            UserRole = UserRoles.ADMIN;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new RoleValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                _errors = validation.Errors.Select(x =>
                                                        x.ErrorMessage).ToList();

                throw new DomainException("some invalid fields", _errors);
            }

            return true;
        }
    }
}
