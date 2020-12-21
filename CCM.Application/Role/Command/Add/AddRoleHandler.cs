using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Role.Command.Add
{
    public class AddRoleHandler: IRequestHandler<AddRole, ResponseModel<AddRoleResponseModel>>
    {
        private readonly ccmContext _context;

        public AddRoleHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<AddRoleResponseModel>> Handle(AddRole request, CancellationToken cancellationToken)
        {
            bool doesExist = _context.Role.Any(role => role.Name.ToLower() == request.Name.ToLower());

            if (doesExist)
            {
                return new ResponseModel<AddRoleResponseModel>()
                {
                    Success = false,
                    Description = "Role name " + request.Name + " already exists"
                };
            }

            await _context.Role.AddAsync(new Domain.Role()
            {
                Name = request.Name
            });
            await _context.SaveChangesAsync();
            
            
            return new ResponseModel<AddRoleResponseModel>()
            {
                Success = true,
                Description = "Successfully added role"
            };
            
        }
    }
}