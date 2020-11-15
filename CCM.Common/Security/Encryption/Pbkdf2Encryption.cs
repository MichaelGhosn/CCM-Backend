using System;
using System.Security.Cryptography;
using CCM.Common.Security.Encryption;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CCM.Common.Security
{
    public class Pbkdf2Encryption: IEncryption
    {
        public string Encrypt(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}