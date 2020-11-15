using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Role.Command.Add
{
    public class AddRoleHandler: IRequestHandler<IAddRole, ResponseModel<AddRoleResponseModel>>
    {
        private ccmContext _context;

        public AddRoleHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<AddRoleResponseModel>> Handle(IAddRole request, CancellationToken cancellationToken)
        {
            bool doesExist = _context.Role.Any(role => role.Name.ToLower() == request.Name.ToLower());

            if (doesExist)
            {
                return new ResponseModel<AddRoleResponseModel>()
                {
                    Success = false,
                    ErrorDescription = "Role name already exists"
                };
            }

            await _context.Role.AddAsync(new Domain.Role()
            {
                Name = request.Name
            });
            _context.SaveChangesAsync();
            
            
            return new ResponseModel<AddRoleResponseModel>()
            {
                Success = true,
            };
            
        }
    }
}