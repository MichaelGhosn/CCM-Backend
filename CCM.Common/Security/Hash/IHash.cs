using System;

namespace CCM.Common.Security.Encryption
{
    public interface IHash
    {
        public String Hash(String password);
        public bool CheckPassword(String password, String hash);
    }
}