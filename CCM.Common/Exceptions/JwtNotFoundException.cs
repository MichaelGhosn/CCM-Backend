using System;

namespace CCM.Common.Exceptions
{
    public class JwtNotFoundException : Exception
    {
        public JwtNotFoundException() : base("JWT not found") {}
    }
}