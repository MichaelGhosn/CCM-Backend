using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Common.Security.Encryption;
using CCM.Common.Security.Tokenizer;
using CCM.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CCM.Application.User.Query.AuthenticateUser
{
    public class AuthenticateUserHandler: IRequestHandler<IAuthenticateUser, ResponseModel<AuthenticateUserResponseModel>>
    {
        private readonly ccmContext _context;
        private readonly IHash _hash;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticateUserHandler(ccmContext context, IHash hash, ITokenGenerator tokenGenerator)
        {
            _context = context;
            _hash = hash;
            _tokenGenerator = tokenGenerator;
        }
        
        public async Task<ResponseModel<AuthenticateUserResponseModel>> Handle(IAuthenticateUser request, CancellationToken cancellationToken)
        {
            Domain.User user = _context.User
                .Include(u => u.Role)
                .Include(u => u.Organisation)
                .FirstOrDefault(u => u.Email == request.Email);

            if (user == null)
            {
                return new ResponseModel<AuthenticateUserResponseModel>()
                {
                    Success = false,
                    Description = "Incorrect email or password"
                };
            }

            bool isPasswordCorrect = _hash.CheckPassword(request.Password, user.Password);

            if (!isPasswordCorrect)
            {
                return new ResponseModel<AuthenticateUserResponseModel>()
                {
                    Success = false,
                    Description = "Incorrect email or password"
                };
            }
            
            return new ResponseModel<AuthenticateUserResponseModel>()
            {
                Success = true,
                Data = new AuthenticateUserResponseModel()
                {
                  JWT  = _tokenGenerator.GenerateToken(new TokenModel()
                  {
                      Email = user.Email,
                      LastName = user.LastName,
                      FirstName = user.FirstName,
                      UserId = user.Id,
                      OrganisationId = user.OrganisationId,
                      OrganisationName = user.Organisation.Name,
                      RoleId = user.RoleId,
                      RoleName = user.Role.Name
                  })
                },
                Description = "User has been successfully authenticated"
            };

        }
    }
}