using System.Collections.Generic;

namespace User.Domain.VOs
{
    public abstract class BaseValueObject
    {
        internal List<string> _errors;

        public IReadOnlyCollection<string> Errors => _errors;
        public abstract bool Validate();
    }
}
