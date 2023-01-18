using System;
using System.Linq;
using User.Domain.Validations;
using User.Infra.CrossCutting.Exceptions;

namespace User.Domain.Entities
{
    public class Error : BaseEntity
    {
        public DateTime Date { get; private set; }
        public string Message { get; private set; }

        protected Error()
        {

        }

        public Error(string message)
        {
            Message = message;
            Date = DateTime.Now;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new ErrorValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                _errors = validation.Errors.Select(x => x.ErrorMessage).ToList();

                throw new DomainException("some invalid fields", Errors.ToList());
            }

            return true;
        }
    }
}
