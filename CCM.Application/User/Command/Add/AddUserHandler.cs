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
        private ccmContext _context;
        private IEncryption _encryption;

        public AddUserHandler(ccmContext context, IEncryption encryption)
        {
            _context = context;
            _encryption = encryption;
        }
        
        public async Task<ResponseModel<AddUserResponseModel>> Handle(IAddUser request, CancellationToken cancellationToken)
        {
            bool doesRoleExists = _context.Role.Any(role => role.Id == request.RoleId);

            if (!doesRoleExists)
            {
                return new ResponseModel<AddUserResponseModel>()
                {
                    Success = false,
                    ErrorDescription = "Role does not exists"
                };    
            }

            bool doesOrganisationExists =
                _context.Organisation.Any(organisation => organisation.Id == request.OrganisationId);

            if (!doesOrganisationExists)
            {
                return new ResponseModel<AddUserResponseModel>()
                {
                    Success = false,
                    ErrorDescription = "Organisation does not exists"
                };    
            }

            bool emailAlreadyExists = _context.User.Any(user => user.Email.ToLower() == request.Email.ToLower());

            if (emailAlreadyExists)
            {
                return new ResponseModel<AddUserResponseModel>()
                {
                    Success = false,
                    ErrorDescription = "Email already exists"
                };  
            }

            _context.User.Add(new Domain.User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = _encryption.Encrypt(request.Password),
                RoleId = request.RoleId,
                OrganisationId = request.OrganisationId
            });

            _context.SaveChangesAsync();
            
            return new ResponseModel<AddUserResponseModel>()
            {
                Success = true,
            };  
        }
    }
}