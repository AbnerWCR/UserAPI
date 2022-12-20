using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using User.Infra.CrossCutting.Encriptation;

namespace User.Infra.CrossCutting.Helpers
{
    public class HelperPassword
    {
        private readonly IConfiguration _configuration;

        public HelperPassword(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreatePasswordHash(string password, Guid guid)
        {
            if (string.IsNullOrEmpty(password))
                throw new Exception("invalid password");

            var keyBytes = PasswordAddKey();
            var salt = FormatHash.Salt(guid);
            var hash = FormatHash.Hash(password, salt, keyBytes);

            return Convert.ToBase64String(hash);
        }

        private byte[] PasswordAddKey()
        {
            return Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        }

        public bool CompareHash(string password, string repoPassword, Guid guid)
        {
            var keyBytes = PasswordAddKey();
            var salt = FormatHash.Salt(guid);

            var respoHash = Convert.FromBase64String(repoPassword);

            return FormatHash.VerifyHash(password, keyBytes, salt, respoHash);
        }
    }
}
