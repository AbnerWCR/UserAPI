using Konscious.Security.Cryptography;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace User.Infra.CrossCutting.Encriptation
{
    public static class FormatHash
    {
        public static byte[] Salt()
        {
            var buffer = new byte[32];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);

            return buffer;
        }

        public static byte[] Hash(string value, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(value));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8;
            argon2.Iterations = 500;
            argon2.MemorySize = Convert.ToInt32(Math.Pow(1024, 2));

            return argon2.GetBytes(32);
        }

        public static bool VerifyHash(string value, byte[] salt, byte[] hash)
        {
            var newHash = Hash(value, salt);
            return hash.SequenceEqual(newHash);
        }
    }
}
