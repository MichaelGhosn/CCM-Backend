using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Role.Command.Delete
{
    public class DeleteRoleHandler: IRequestHandler<DeleteRole, ResponseModel<DeleteRoleResponseModel>>
    {
        private readonly ccmContext _context;

        public DeleteRoleHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<DeleteRoleResponseModel>> Handle(DeleteRole request, CancellationToken cancellationToken)
        {
            Domain.Role role = _context.Role.FirstOrDefault(role => role.Id == request.Id);

            if (role == null)
            {
                return new ResponseModel<DeleteRoleResponseModel>()
                {
                    Success = false,
                    Description = "Role does not exist to be deleted"
                };
            }

            _context.Role.Remove(role);
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ResponseModel<DeleteRoleResponseModel>()
            {
                Success = true,
                Description = "Successfully deleted role"
            };
        }
    }
}