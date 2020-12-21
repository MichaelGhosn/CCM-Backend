using System;

namespace CCM.Common.Security.Tokenizer
{
    public abstract class TokenGenerator
    {
        public abstract String GenerateToken(TokenModel model);
    }
}