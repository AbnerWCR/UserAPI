using System.Linq;
using User.Domain.Validations;
using User.Infra.CrossCutting.Exceptions;

namespace User.Domain.VOs
{
    public class Name : BaseValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string FullName => $"{FirstName} {LastName}";

        public Name()
        {

        }

        public Name(string firsName, string lastName)
        {
            FirstName = firsName;
            LastName = lastName;
            Validate();
        }

        public void ChangeFirstName(string firstName)
        {
            FirstName = firstName;
            Validate();
        }

        public void ChangeLastName(string lastName)
        {
            LastName = lastName;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new NameValidator();
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
