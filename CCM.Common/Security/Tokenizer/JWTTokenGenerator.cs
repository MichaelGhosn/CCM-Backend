using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CCM.Common.Security.Tokenizer
{
    public class JWTTokenGenerator: TokenGenerator
    {
        public IConfiguration Configuration { get; }

        public JWTTokenGenerator(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public override string GenerateToken(TokenModel model)
        {
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["JwtSecret"]));
            
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", model.UserId.ToString()),
                    new Claim("UserName", model.FirstName),
                    new Claim("LastName", model.LastName),
                    new Claim("Email", model.Email),
                    new Claim("RoleName", model.RoleName),
                    new Claim("OrganisationId", model.OrganisationId.ToString()),
                    new Claim("OrganisationName", model.OrganisationName),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = "Michael Ghosn",
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
            
        }
    }
}