using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Common.Security.Encryption;
using CCM.Domain;
using MediatR;

namespace CCM.Application.User.Command.Add
{
    public class AddUserHandler: IRequestHandler<IAddUser, ResponseModel<AddUserResponseModel>>
    {
        private readonly ccmContext _context;
        private readonly IHash _hash;

        public AddUserHandler(ccmContext context, IHash hash)
        {
            _context = context;
            _hash = hash;
        }
        
        public async Task<ResponseModel<AddUserResponseModel>> Handle(IAddUser request, CancellationToken cancellationToken)
        {
            bool doesRoleExists = _context.Role.Any(role => role.Id == request.RoleId);

            if (!doesRoleExists)
            {
                return new ResponseModel<AddUserResponseModel>()
                {
                    Success = false,
                    Description = "Role does not exists"
                };    
            }

            bool doesOrganisationExists =
                _context.Organisation.Any(organisation => organisation.Id == request.OrganisationId);

            if (!doesOrganisationExists)
            {
                return new ResponseModel<AddUserResponseModel>()
                {
                    Success = false,
                    Description = "Organisation does not exists"
                };    
            }

            bool emailAlreadyExists = _context.User.Any(user => user.Email.ToLower() == request.Email.ToLower());

            if (emailAlreadyExists)
            {
                return new ResponseModel<AddUserResponseModel>()
                {
                    Success = false,
                    Description = "Email already exists"
                };  
            }

            _context.User.Add(new Domain.User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = _hash.Hash(request.Password),
                RoleId = request.RoleId,
                OrganisationId = request.OrganisationId
            });

            _context.SaveChangesAsync();
            
            return new ResponseModel<AddUserResponseModel>()
            {
                Success = true,
                Description = "Successfully added user"
            };  
        }
    }
}