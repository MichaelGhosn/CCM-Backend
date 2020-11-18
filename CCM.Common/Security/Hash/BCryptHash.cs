using System;
using System.Security.Cryptography;
using CCM.Common.Security.Encryption;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CCM.Common.Security
{
    public class BCryptHash: IHash
    {
        public String Hash(String password)
        {
           return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool CheckPassword(string password, string hash)
        {
            return  BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}