using System.Linq;
using User.Domain.Validations;
using User.Infra.CrossCutting.Exceptions;

namespace User.Domain.VOs
{
    public class Email : BaseValueObject
    {
        public string Address { get; private set; }

        protected Email()
        {

        }

        public Email(string address)
        {
            Address = address;
            Validate();
        }

        public void ChangeAddress(string address)
        {
            Address = address;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new EmailValidator();
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
