using Konscious.Security.Cryptography;
using System;
using System.Linq;
using System.Text;

namespace User.Infra.CrossCutting.Encriptation
{
    public static class FormatHash
    {
        public static byte[] Salt(Guid guid)
        {
            var buffer = guid.ToByteArray();

            return buffer;
        }

        public static byte[] Hash(string value, byte[] salt, byte[] keyBytes)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(value));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 16;
            argon2.Iterations = 400;
            argon2.MemorySize = 8192;
            argon2.AssociatedData = keyBytes;

            return argon2.GetBytes(128);
        }

        public static bool VerifyHash(string value, byte[] keyBytes, byte[] salt, byte[] hash)
        {
            var newHash = Hash(value, salt, keyBytes);
            return hash.SequenceEqual(newHash);
        }
    }
}
