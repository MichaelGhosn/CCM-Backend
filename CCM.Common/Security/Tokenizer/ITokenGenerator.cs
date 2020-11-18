using System;

namespace CCM.Common.Security.Tokenizer
{
    public abstract class ITokenGenerator
    {
        public abstract String GenerateToken(TokenModel model);
    }
}