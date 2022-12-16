using System;
using System.Collections.Generic;

namespace User.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; private set; }
        internal List<string> _errors;

        public IReadOnlyCollection<string> Errors => _errors;
        public abstract bool Validate();
    }
}
