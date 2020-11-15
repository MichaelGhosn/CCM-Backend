using System;

namespace CCM.Common.Security.Encryption
{
    public interface IEncryption
    {
        public String Encrypt(string password);
    }
}