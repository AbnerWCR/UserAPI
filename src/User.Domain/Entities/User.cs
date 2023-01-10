using System.Collections.Generic;
using System.Linq;
using User.Domain.Validations;
using User.Domain.VOs;
using User.Infra.CrossCutting.Exceptions;

namespace User.Domain.Entities
{
    public class User : BaseEntity
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Role Role { get; private set; }

        //empty constructor for EF
        protected User()
        { 

        }

        public User(Name name, Email email, Password password, Role role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            _errors = new List<string>();

            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();

            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                _errors = validation.Errors.Select(x => x.ErrorMessage).ToList();

                throw new DomainException("some invalid fields", _errors);
            }

            return true;
        }
    }
}
