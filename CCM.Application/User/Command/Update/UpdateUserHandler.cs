using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Common.Security.Encryption;
using CCM.Domain;
using MediatR;

namespace CCM.Application.User.Command.Update
{
    public class UpdateUserHandler: IRequestHandler<UpdateUser, ResponseModel<UpdateUserResponseModel>>
    {
        private readonly ccmContext _context;
        private IHash _hash;

        public UpdateUserHandler(ccmContext context, IHash hash)
        {
            _context = context;
            _hash = hash;
        }

        public async Task<ResponseModel<UpdateUserResponseModel>> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            Domain.User user = _context.User.FirstOrDefault(u => u.Id == request.Id);

            if (user == null)
            {
                return new ResponseModel<UpdateUserResponseModel>()
                {
                    Success = false,
                    Description = "No user found"
                };
            }

            
            if (!String.IsNullOrEmpty(request.Email) && 
                user.Email.ToLower() != request.Email.ToLower() && 
                _context.User.Any(u => u.Email.ToLower() == request.Email.ToLower()))
            {
                return new ResponseModel<UpdateUserResponseModel>()
                {
                    Success = false,
                    Description = "Email already exists"
                };
            }

            if (request.OrganisationId > 0 &&
                _context.Organisation.Any(organisation => organisation.Id == request.OrganisationId) == false)
            {
                return new ResponseModel<UpdateUserResponseModel>()
                {
                    Success = false,
                    Description = "Invalid organisation"
                };
            }
            
            if (request.RoleId > 0 &&
                _context.Role.Any(role => role.Id == request.RoleId) == false)
            {
                return new ResponseModel<UpdateUserResponseModel>()
                {
                    Success = false,
                    Description = "Invalid role"
                };
            }
            
            user.FirstName = String.IsNullOrEmpty(request.FirstName) ? user.FirstName : request.FirstName;
            user.LastName = String.IsNullOrEmpty(request.LastName) ? user.LastName : request.LastName;
            user.Email = String.IsNullOrEmpty(request.Email) ? user.Email : request.Email;
            user.Password = String.IsNullOrEmpty(request.Password) ? user.Password : _hash.Hash(request.Password);
            user.OrganisationId = request.OrganisationId == 0 ? user.OrganisationId : request.OrganisationId;
            user.RoleId = request.RoleId == 0 ? user.RoleId : request.RoleId;
            
            _context.User.Update(user);

            await _context.SaveChangesAsync();
            
            return new ResponseModel<UpdateUserResponseModel>()
            {
                Success = true,
                Description = "Successfully updated user"
            };
        }
    }
}