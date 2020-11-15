using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Role.Command.Update
{
    public class UpdateRoleHandler: IRequestHandler<IUpdateRole, ResponseModel<UpdateRoleResponseModel>>
    {
        private ccmContext _context;

        public UpdateRoleHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<UpdateRoleResponseModel>> Handle(IUpdateRole request, CancellationToken cancellationToken)
        {
            Domain.Role role = _context.Role.FirstOrDefault(role => role.Id == request.Id);

            if (role == null)
            {
                return new ResponseModel<UpdateRoleResponseModel>()
                {
                    Success = false,
                    ErrorDescription = "Role does not exists"
                };
            }

            role.Name = request.Name;
            
            _context.Role.Update(role);
            _context.SaveChangesAsync();
            
            return new ResponseModel<UpdateRoleResponseModel>()
            {
                Success = true
            };
        }
    }
}