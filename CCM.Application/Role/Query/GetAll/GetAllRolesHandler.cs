using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CCM.Application.Models;
using CCM.Domain;
using MediatR;

namespace CCM.Application.Role.Query.GetAll
{
    public class GetAllRolesHandler: IRequestHandler<IGetAllRoles, ResponseModel<List<GetAllRolesResponseModel>>>
    {
        private ccmContext _context;

        public GetAllRolesHandler(ccmContext context)
        {
            _context = context;
        }
        
        public async Task<ResponseModel<List<GetAllRolesResponseModel>>> Handle(IGetAllRoles request, CancellationToken cancellationToken)
        {
            return new ResponseModel<List<GetAllRolesResponseModel>>()
            {
                Success = true,
                Data = _context.Role.Select(role => new GetAllRolesResponseModel()
                {
                    Id = role.Id,
                    Name = role.Name
                }).ToList(),
                Description = "Successfully fetched data"
            };
        }
    }
}