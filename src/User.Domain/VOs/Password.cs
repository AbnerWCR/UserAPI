using System;
using System.Linq;
using User.Domain.Validations;
using User.Infra.CrossCutting.Encriptation;
using User.Infra.CrossCutting.Exceptions;

namespace User.Domain.VOs
{
    public class Password : BaseValueObject
    {
        public string PasswordText { get; private set; }
        public string PasswordHash { get; private set; }
        private byte[] Key { get; set; }

        public Password()
        {

        }

        public Password(string passwordText)
        {
            PasswordText = passwordText;
            Validate();
        }

        public void ChangePassword(string passwordText)
        {
            PasswordText = passwordText;
            Validate();
        }

        public void AddKey(byte[] key)
        {
            Key = key;
            Validate();
        }

        public void CreatePasswordHash(Guid userId)
        {
            if (string.IsNullOrEmpty(PasswordText))
                throw new Exception("invalid password");

            var salt = FormatHash.Salt(userId);
            var hash = FormatHash.Hash(PasswordText, salt, Key);

            PasswordHash = Convert.ToBase64String(hash);
        }

        public bool CompareHash(string repoPassword, Guid userId)
        {
            var salt = FormatHash.Salt(userId);
            var respoHash = Convert.FromBase64String(repoPassword);

            return FormatHash.VerifyHash(PasswordText, Key, salt, respoHash);
        }

        public override bool Validate()
        {
            var validator = new PasswordValidator();
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
