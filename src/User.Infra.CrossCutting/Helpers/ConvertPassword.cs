using System;
using User.Infra.CrossCutting.Encriptation;

namespace User.Infra.CrossCutting.Helpers
{
    public sealed class ConvertPassword
    {
        public string CreatePasswordHash(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new Exception("invalid password");

            var passwordWithKey = PasswordAddKey(password);
            var salt = FormatHash.Salt();
            var hash = FormatHash.Hash(passwordWithKey, salt);

            return Convert.ToBase64String(hash);
        }

        private string PasswordAddKey(string password)
        {
            return string.Concat(password, "teste@salvar$senha-api");
        }

        public bool CompareHash(string password, string repoPassword)
        {
            var passwordWithKey = PasswordAddKey(password);
            var salt = FormatHash.Salt();

            var respoHash = Convert.FromBase64String(repoPassword);

            return FormatHash.VerifyHash(passwordWithKey, salt, respoHash);
        }
    }
}
